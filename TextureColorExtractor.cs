using UnityEngine;
using System.Collections;

namespace Littlstar.Utility {

	public static class TextureColorExtractor {

		private static float COLOR_MULTIPLIER = 255.999f;

		/// <summary>
		/// Returns the average color of all pixels found within a Texture object
		/// </summary>
		/// <returns>The average color</returns>
		/// <param name="texture">Texture object to find the average color of</param>
		public static Color GetAvergaeColor (Texture texture) {
			Texture2D t = texture as Texture2D;
			return GetDominantColor (t.GetPixels ());
		}

		/// <summary>
		/// Returns the average color of all pixels found within a Texture2D object
		/// </summary>
		/// <returns>The average color</returns>
		/// <param name="texture">Texture2D object to find the average color of</param>
		public static Color GetAverageColor (Texture2D texture) {
			return GetDominantColor (texture.GetPixels ());
		}

		/// <summary>
		/// Returns the average color of an array of Colors
		/// </summary>
		/// <returns>The average color</returns>
		/// <param name="colors">Average color of the array</param>
		public static Color GetDominantColor(Color[] colors) {
			int pixelCount = colors.Length;
			float r = 0f, g = 0f, b = 0f;
			foreach (Color color in colors) {
				r += color.r;
				g += color.g;
				b += color.b;
			}

			r /= pixelCount;
			g /= pixelCount;
			b /= pixelCount;

			r = Mathf.Round (r * COLOR_MULTIPLIER);
			g = Mathf.Round (g * COLOR_MULTIPLIER);
			b = Mathf.Round (b * COLOR_MULTIPLIER);

			Color dominantColor = new Color (r, g, b, 1f);
			return dominantColor;
		}

		/// <summary>
		/// Gets the average color from a section of a Texture object
		/// </summary>
		/// <returns>The average color of the pixels within the Rect</returns>
		/// <param name="texture">Texture that the operation is being performed on</param>
		/// <param name="pixelBlock">Rect on the texture to find the average of</param>
		public static Color GetAverageColorFromRect(Texture texture, Rect pixelBlock) {
			Texture2D t = texture as Texture2D;
			Color[] pixels = GetRectPixelsFromTexture (t, pixelBlock);
			return GetDominantColor (pixels);
		}

		/// <summary>
		/// Gets the average color from a section of a Texture2D object
		/// </summary>
		/// <returns>The average color of the pixels within the Rect</returns>
		/// <param name="texture">Texture that the operation is being performed on</param>
		/// <param name="pixelBlock">Rect on the texture to find the average of</param>
		public static Color GetAverageColorFromRect(Texture2D texture, Rect pixelBlock) {
			Color[] pixels = GetRectPixelsFromTexture (texture, pixelBlock);
			return GetDominantColor (pixels);
		}
			
		private static Color[] GetRectPixelsFromTexture(Texture2D texture, Rect pixelBlock) {

			int pbx = Mathf.FloorToInt (pixelBlock.x);
			int pby = Mathf.FloorToInt (pixelBlock.y);
			int pbw = Mathf.FloorToInt (pixelBlock.width);
			int pbh = Mathf.FloorToInt (pixelBlock.height);

			if (pbx < 0 || pbx > texture.width || pbw > texture.width || pbh > texture.height) {
				return null;
			}

			Color[] rectPixels = texture.GetPixels (pbx, pby, pbw, pbh);
			return rectPixels;
		}

	}

}
