// dllmain.cpp : Definiuje punkt wejścia dla aplikacji DLL.
#include "pch.h"
#include <vector>
#include <algorithm>
#include <cmath>
#include <cstdlib>
#include <random>
#include <Windows.h>

extern "C" __declspec(dllexport) void ApplyBlurAtPixelCpp(float* matrix, float factor, uint32_t * sourcePixels, uint32_t * resultPixels, int width, int height, int x, int y)
{
    float red = 0, green = 0, blue = 0;

    for (int m = -1; m <= 1; m++)
    {
        for (int n = -1; n <= 1; n++)
        {
            int offsetX = x + m;
            int offsetY = y + n;

            // Ensure the offset is within bounds
            offsetX = max(0, min(offsetX, width - 1));
            offsetY = max(0, min(offsetY, height - 1));

            uint32_t pixelColor = sourcePixels[offsetY * width + offsetX];
            float weight = matrix[(n + 1) * 3 + (m + 1)]; // Adjusted index for flattened matrix

            red += (pixelColor & 0xFF) * weight;
            green += ((pixelColor >> 8) & 0xFF) * weight;
            blue += ((pixelColor >> 16) & 0xFF) * weight;
        }
    }

    if (factor != 0) // Avoid division by zero
    {
        red /= factor;
        green /= factor;
        blue /= factor;
    }

    red = min(255, max(0, red));
    green = min(255, max(0, green));
    blue = min(255, max(0, blue));

    uint32_t updatedColor = (255 << 24) | ((int)blue << 16) | ((int)green << 8) | (int)red;

    // Update the resultPixels using the new Color instance
    resultPixels[y * width + x] = updatedColor;
}



