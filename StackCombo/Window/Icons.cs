using Dalamud.Interface.Textures;
using Dalamud.Interface.Textures.TextureWraps;
using Dalamud.Utility;
using ECommons.DalamudServices;
using Lumina.Data.Files;
using System.Collections.Generic;

namespace StackCombo.Window
{
	internal static class Icons
	{
		public static Dictionary<uint, IDalamudTextureWrap> CachedModdedIcons = [];
		public static IDalamudTextureWrap? GetJobIcon(uint jobId)
		{
			if (jobId is 0 or > 42)
			{
				return null;
			}

			IDalamudTextureWrap? icon = GetTextureFromIconId(62100 + jobId);

			return icon;
		}

		private static string ResolvePath(string path)
		{
			return Svc.TextureSubstitution.GetSubstitutedPath(path);
		}

		public static IDalamudTextureWrap? GetTextureFromIconId(uint iconId, uint stackCount = 0, bool hdIcon = true)
		{
			GameIconLookup lookup = new(iconId + stackCount, false, hdIcon);
			string path = Svc.Texture.GetIconPath(lookup);
			string resolvePath = ResolvePath(path);

			ISharedImmediateTexture wrap = Svc.Texture.GetFromFile(resolvePath);
			if (wrap.TryGetWrap(out IDalamudTextureWrap? icon, out _))
			{
				return icon;
			}

			try
			{
				if (CachedModdedIcons.ContainsKey(iconId))
				{
					return CachedModdedIcons[iconId];
				}

				TexFile tex = Svc.Data.GameData.GetFileFromDisk<TexFile>(resolvePath);
				IDalamudTextureWrap output = Svc.Texture.CreateFromRaw(RawImageSpecification.Rgba32(tex.Header.Width, tex.Header.Width), tex.GetRgbaImageData());
				if (output != null)
				{
					CachedModdedIcons[iconId] = output;
					return output;
				}
			}
			catch { }


			return Svc.Texture.GetFromGame(path).GetWrapOrDefault();
		}
	}
}
