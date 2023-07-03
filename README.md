# game-dev-geometry-math
A Collection of Game Dev Geometry based snippets

## Why?

When I started building games in Unity (C#) I found myself needing many functions to calculate common geometry functions.
I was hoping such a repo existed somewhere, and I could just use it, but I didn't find one.
So I wanted to collect the best, optimized examples from the Internet/experts... and organize them for fellow developers that might want to use them.

Although my focus here is in C#, for Unity development, if this is of any value to others, I will add C++, Java/Kotlin, Python examples as well.

## Key Desired Methods

### 2D
 1. Determine [which side of a line (2D) a point is on](https://github.com/scunliffe/game-dev-geometry-math/blob/main/c-sharp/geometry.cs#L70)
 2. Determine if a point is inside a (2D) shape (rectangle, triangle, circle, polygon)
 3. Determine the centroid of a (2D) shape (rectangle, triangle, circle, polygon)
 4. Determine the normal for a line
 5. Determine the [angle between 2 lines](https://github.com/scunliffe/game-dev-geometry-math/blob/main/c-sharp/geometry.cs#L13)
 6. Determine if 2 lines intersect, and if so where

### 3D
 1. Determine if a point is within a (3D) shape (rectangular prism/cuboid, sphere, cone, cylinder, pyramid)
 2. Determine which side of (3D) plane a point is on
 3. Determine the [midpoint of a line](https://github.com/scunliffe/game-dev-geometry-math/blob/main/c-sharp/geometry.cs#L113)
 4. Determine if a point is on a line (with a fuzz factor)
 5. Determine the normal for a plane
 6. Determine if 2 lines intersect, and if so where
 7. Determine where a line intersects a plane


Yo! This is awesome, but what gives? camelCase method names, OTB brace style, and tabs for indentation?... this isn't the C# way!
Yup, this was intentional. I come from a Java/JavaScript world where methods start lowercase and its just so much easier for me to work with... and well the brace/indentaion styling are just my preferences.
