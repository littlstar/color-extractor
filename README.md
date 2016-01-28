# color-extractor

Simple utility for Unity3D for finding the average color of a texture.

# Usage

Import the namespace:

``` csharp
using Littlstar.Utility;
```

Getting the average color:

``` csharp
Color averageColor = TextureColorExtractor.GetAverageColor (myTexture);
```

You can also get the average colors from a rectangular section of a texture:

``` csharp
Rect leftSideRect = new Rect(0f, 0f, myTexture.width / 2f, myTexture.height / 2f);
Color averageRectColor = TextureColorExtractor.GetAverageColorFromRect (myTexture, leftSideRect);
```

This gets the average color of the left half of the provided texture. You can pass either a Texture, a Texture2D, or just an array of Color objects to both the GetAverageColor and GetAverageColorFromRect methods.

# License

MIT
