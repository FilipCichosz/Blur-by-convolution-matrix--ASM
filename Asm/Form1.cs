using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Windows.Forms;



namespace Asm
{
    public partial class Form1 : Form
    {
        float[] inputRGB = new float[3];
        float[] inputScalar = new float[3];
        float[] output = new float[3];
        String inputImagePath;

        [DllImport(@"C:\Users\Wodna Bestyja\source\repos\Assembler\Asm\x64\Debug\C__PLUS_PLUS_Blur.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void ApplyBlurAtPixelCpp(float[] matrix, float factor, IntPtr sourcePixels, IntPtr resultPixels, int width, int height, int x, int y);

        
        [DllImport(@"C:\Users\Wodna Bestyja\source\repos\Assembler\Asm\x64\Debug\Blur.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ASMfuncmul(float[] tabw, float[] rgb, float[] rgbw, float[] factor);
        [DllImport(@"C:\Users\Wodna Bestyja\source\repos\Assembler\Asm\x64\Debug\Blur.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ASMfuncdiv(float[] rgbw, float[] factor);



        public Form1()
        {
            InitializeComponent();
            label1.Text = $"Current threads: {trackBar1.Value}";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            String imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;

                    // Load the image
                    Image originalImage = Image.FromFile(imageLocation);

                    // Resize the image to fit pictureBox1
                    pictureBox1.Image = ResizeImage(originalImage, pictureBox1.Size);

                    // Store the input image path
                    inputImagePath = imageLocation;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Image ResizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap inputImage = new Bitmap(pictureBox1.Image);

                // Get matrix values from textboxes
                float[,] customMatrix = GetCustomMatrix();
                int numberOfThreads = trackBar1.Value;
                bool isIdentityMatrix = IsIdentityMatrix(customMatrix);


                if (customMatrix != null)
                {
                    if (isIdentityMatrix)
                    {
                        pictureBox2.Image = inputImage;
                    }
                    else
                    {
                        if (radioButton2.Checked)
                        {
                            Stopwatch stopwatch = Stopwatch.StartNew();
                            pictureBox2.Image = ApplyCustomMatrixBlurMultiThreaded(inputImage, customMatrix, numberOfThreads);
                            stopwatch.Stop();
                            label2.Text = $"Elapsed Time: {stopwatch.ElapsedMilliseconds} ms";
                        }
                        if (radioButton1.Checked || radioButton3.Checked )
                        {
                            if (radioButton1.Checked)
                            {
                                Stopwatch stopwatch = Stopwatch.StartNew();
                                pictureBox2.Image = ApplyCustomMatrixBlurMultiThreaded222(inputImage, customMatrix, numberOfThreads);
                                stopwatch.Stop();
                                label2.Text = $"Elapsed Time: {stopwatch.ElapsedMilliseconds} ms";
                            }
                            else
                            {
                                Stopwatch stopwatch = Stopwatch.StartNew();
                                pictureBox2.Image = ApplyCustomMatrixBlurMultiThreadedLine(inputImage, customMatrix, numberOfThreads);
                                stopwatch.Stop();
                                label2.Text = $"Elapsed Time: {stopwatch.ElapsedMilliseconds} ms";
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid matrix values. Please enter valid numeric values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private static byte[] ImageToByteArray(Bitmap image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private static Bitmap ByteArrayToImage(byte[] byteArray)
        {
            using (var ms = new MemoryStream(byteArray))
            {
                return new Bitmap(ms);

            }
        }
        private float[,] GetCustomMatrix()
        {
            float[,] customMatrix = new float[3, 3];

            try
            {
                // Parse matrix values from textboxes
                if (textBox1.Text.ToString().Contains("/"))
                {
                    customMatrix[0, 0] = Fraction.Parse(textBox1.Text).ToFloat();
                }
                else {
                    customMatrix[0, 0] = float.Parse(textBox1.Text);
                }
                if (textBox1.ToString().Contains("/"))
                {
                    customMatrix[0, 1] = Fraction.Parse(textBox2.Text).ToFloat();
                }
                else
                {
                    customMatrix[0, 1] = float.Parse(textBox2.Text);
                }
                if (textBox1.ToString().Contains("/"))
                {
                    customMatrix[0, 2] = Fraction.Parse(textBox3.Text).ToFloat();
                }
                else
                {
                    customMatrix[0, 2] = float.Parse(textBox3.Text);
                }
                if (textBox1.ToString().Contains("/"))
                {
                    customMatrix[1, 0] = Fraction.Parse(textBox4.Text).ToFloat();
                }
                else
                {
                    customMatrix[1, 0] = float.Parse(textBox4.Text);
                }
                if (textBox1.ToString().Contains("/"))
                {
                    customMatrix[1, 1] = Fraction.Parse(textBox5.Text).ToFloat();
                }
                else
                {
                    customMatrix[1, 1] = float.Parse(textBox5.Text);
                }
                if (textBox1.ToString().Contains("/"))
                {
                    customMatrix[1, 2] = Fraction.Parse(textBox6.Text).ToFloat();
                }
                else
                {
                    customMatrix[1, 2] = float.Parse(textBox6.Text);
                }
                if (textBox1.ToString().Contains("/"))
                {
                    customMatrix[2, 0] = Fraction.Parse(textBox7.Text).ToFloat();
                }
                else
                {
                    customMatrix[2, 0] = float.Parse(textBox7.Text);
                }
                if (textBox1.ToString().Contains("/"))
                {
                    customMatrix[2, 1] = Fraction.Parse(textBox8.Text).ToFloat();
                }
                else
                {
                    customMatrix[2, 1] = float.Parse(textBox8.Text);
                }
                if (textBox1.ToString().Contains("/"))
                {
                    customMatrix[2, 2] = Fraction.Parse(textBox9.Text).ToFloat();
                }
                else
                {
                    customMatrix[2, 2] = float.Parse(textBox9.Text);
                }

                return customMatrix;
            }
            catch (FormatException)
            {
                // Handle the case where parsing fails (non-numeric values entered)
                return null;
            }
        }


        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            // Update the label when the trackbar value changes
            label1.Text = $"Current threads: {trackBar1.Value}";
        }
        private bool IsIdentityMatrix(float[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows != cols)
            {
                return false; // Not a square matrix
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if ((i == j && matrix[i, j] != 1.0f) || (i != j && matrix[i, j] != 0.0f))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //asembler
            if (radioButton1.Checked)
            {
                // Option 1 is selected
                radioButton3.Checked = false;
                radioButton2.Checked = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //c#
            if (radioButton2.Checked)
            {
                // Option 1 is selected
                radioButton1.Checked = false;
                radioButton3.Checked = false;

            }
        }

        private void Save_Click(object sender, EventArgs e)
        {

            if (pictureBox1.Image != null)
            {
                Bitmap inputImage = new Bitmap(pictureBox1.Image);

                // Get matrix values from textboxes
                float[,] customMatrix = GetCustomMatrix();
                int numberOfThreads = trackBar1.Value;

                if (customMatrix != null)
                {

                }
                else
                {
                    MessageBox.Show("Invalid matrix values. Please enter valid numeric values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private static readonly object lockObject = new object();




        private Bitmap ApplyCustomMatrixBlurMultiThreaded(Bitmap image, float[,] matrix, int numberOfThreads)
        {
            int width = image.Width;
            int height = image.Height;
            Bitmap result = new Bitmap(width, height);

            float factor = matrix.Cast<float>().Sum();

            Color[,] sourcePixels = new Color[width, height];
            Color[,] resultPixels = new Color[width, height];

            BitmapData imageData = image.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            unsafe
            {
                byte* imagePtr = (byte*)imageData.Scan0.ToPointer();

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        byte* pixel = imagePtr + y * imageData.Stride + x * 4;
                        sourcePixels[x, y] = Color.FromArgb(pixel[3], pixel[2], pixel[1], pixel[0]);
                    }
                }
            }

            image.UnlockBits(imageData);

            ParallelOptions parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = numberOfThreads };

            Parallel.For(0, height, parallelOptions, y =>
            {
                for (int x = 0; x < width; x++)
                {
                    float red = 0, green = 0, blue = 0;

                    for (int m = -1; m <= 1; m++)
                    {
                        for (int n = -1; n <= 1; n++)
                        {
                            int offsetX = x + m;
                            int offsetY = y + n;

                            // Ensure the offset is within bounds
                            offsetX = Math.Max(0, Math.Min(offsetX, width - 1));
                            offsetY = Math.Max(0, Math.Min(offsetY, height - 1));

                            Color pixelColor = sourcePixels[offsetX, offsetY];
                            float weight = matrix[m + 1, n + 1];

                            red += pixelColor.R * weight;
                            green += pixelColor.G * weight;
                            blue += pixelColor.B * weight;
                        }
                    }

                    if (factor != 0) // Avoid division by zero
                    {
                        red /= factor;
                        green /= factor;
                        blue /= factor;
                    }

                    red = Math.Min(255, Math.Max(0, red));
                    green = Math.Min(255, Math.Max(0, green));
                    blue = Math.Min(255, Math.Max(0, blue));

                    Color updatedColor = Color.FromArgb(255, (int)red, (int)green, (int)blue);

                    // Use a lock to protect the critical section
                    lock (lockObject)
                    {
                        // Update the resultPixels using the new Color instance
                        resultPixels[x, y] = updatedColor;
                    }

                }
            });

            BitmapData resultData = result.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            unsafe
            {
                byte* resultPtr = (byte*)resultData.Scan0.ToPointer();

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        byte* pixel = resultPtr + y * resultData.Stride + x * 4;
                        Color resultColor = resultPixels[x, y];

                        pixel[0] = resultColor.B;
                        pixel[1] = resultColor.G;
                        pixel[2] = resultColor.R;
                        pixel[3] = 255; // Set alpha to 255
                    }
                }
            }

            result.UnlockBits(resultData);

            return result;
        }

        public Bitmap ApplyCustomMatrixBlurMultiThreadedLine(Bitmap image, float[,] matrix, int numberOfThreads)
        {
            int width = image.Width;
            int height = image.Height;

            Color[,] sourcePixels = new Color[width, height];
            Color[,] resultPixels = new Color[width, height];

            
            ExtractSourcePixels(image, sourcePixels);
            
            IntPtr flattenedSourcePixels = FlattenArray(sourcePixels, width, height);
            IntPtr flattenedResultPixels = FlattenArray(resultPixels, width, height);

            ApplyBlur(matrix, flattenedSourcePixels, flattenedResultPixels, width, height, numberOfThreads);

            Bitmap result = CreateBitmapFromPixels(flattenedResultPixels, width, height);

            return result;
        }

        private float[] FlattenMatrix(float[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            float[] flattenedMatrix = new float[rows * cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    flattenedMatrix[i * cols + j] = matrix[i, j];
                }
            }

            return flattenedMatrix;
        }

        private IntPtr FlattenArray(Color[,] array, int width, int height)
        {
            int dataSize = width * height;
            uint[] flattenedData = new uint[dataSize];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Color pixel = array[j, i];
                    flattenedData[i * width + j] = (uint)(pixel.A << 24 | pixel.R << 16 | pixel.G << 8 | pixel.B);
                }
            }

            // Convert uint[] to byte[]
            byte[] flattenedBytes = new byte[sizeof(uint) * dataSize];
            Buffer.BlockCopy(flattenedData, 0, flattenedBytes, 0, flattenedBytes.Length);

            // Allocate memory and copy the byte array
            IntPtr flattenedArray = Marshal.AllocCoTaskMem(flattenedBytes.Length);
            Marshal.Copy(flattenedBytes, 0, flattenedArray, flattenedBytes.Length);

            return flattenedArray;
        }

        private float CalculateFactor(float[,] matrix)
        {
            return matrix.Cast<float>().Sum();
        }

        private void ExtractSourcePixels(Bitmap image, Color[,] sourcePixels)
        {
            int width = image.Width;
            int height = image.Height;

            BitmapData imageData = image.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            unsafe
            {
                byte* imagePtr = (byte*)imageData.Scan0.ToPointer();

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        byte* pixel = imagePtr + y * imageData.Stride + x * 4;
                        sourcePixels[x, y] = Color.FromArgb(pixel[3], pixel[2], pixel[1], pixel[0]);
                    }
                }
            }

            image.UnlockBits(imageData);
        }

        private void ApplyBlur(float[,] matrix, IntPtr flattenedSourcePixels, IntPtr flattenedResultPixels, int width, int height, int numberOfThreads)
        {
            ParallelOptions parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = numberOfThreads };

            Parallel.For(0, height, parallelOptions, y =>
            {
                for (int x = 0; x < width; x++)
                {

                    ApplyBlurAtPixel(matrix, flattenedSourcePixels, flattenedResultPixels, width, height, x, y);
                }
            });
        }

        private void ApplyBlurAtPixel(float[,] matrix, IntPtr flattenedSourcePixels, IntPtr flattenedResultPixels, int width, int height, int x, int y)
        {
            int dataSize = width * height;

            // Flatten the 2D arrays for passing to C++
            float[] flattenedMatrix = FlattenMatrix(matrix);
            IntPtr matrixPtr = Marshal.UnsafeAddrOfPinnedArrayElement(matrix, 0);


            if (radioButton1.Checked)
            {
                
            }
            else
            {
                ApplyBlurAtPixelCpp(flattenedMatrix, CalculateFactor(matrix), flattenedSourcePixels, flattenedResultPixels, width, height, x, y);
            }

        }

        private Bitmap CreateBitmapFromPixels(IntPtr flattenedResultPixels, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);

            BitmapData resultData = result.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            unsafe
            {
                byte* resultPtr = (byte*)resultData.Scan0.ToPointer();

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        // Calculate the index in the flattened array
                        int index = y * width + x;

                        // Get the color values from the flattened array
                        uint pixelValue = (uint)Marshal.ReadInt32(flattenedResultPixels, index * sizeof(uint));
                        Color resultColor = Color.FromArgb((int)pixelValue);

                        // Set pixel values directly without unflattening
                        byte* pixel = resultPtr + y * resultData.Stride + x * 4;
                        pixel[0] = resultColor.B;
                        pixel[1] = resultColor.G;
                        pixel[2] = resultColor.R;
                        pixel[3] = resultColor.A;
                    }
                }
            }

            result.UnlockBits(resultData);

            return result;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                // Option 1 is selected
                radioButton1.Checked = false;
                radioButton2.Checked = false;
            }
        }

        private Bitmap ApplyCustomMatrixBlurMultiThreaded222(Bitmap image, float[,] matrix, int numberOfThreads)
        {
            int width = image.Width;
            int height = image.Height;
            Bitmap result = new Bitmap(width, height);

            float factor = matrix.Cast<float>().Sum();
            float[] factortable = { factor, factor, factor };
            Color[,] sourcePixels = new Color[width, height];
            Color[,] resultPixels = new Color[width, height];

            BitmapData imageData = image.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            unsafe
            {
                byte* imagePtr = (byte*)imageData.Scan0.ToPointer();

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        byte* pixel = imagePtr + y * imageData.Stride + x * 4;
                        sourcePixels[x, y] = Color.FromArgb(pixel[3], pixel[2], pixel[1], pixel[0]);
                    }
                }
            }

            image.UnlockBits(imageData);

            ParallelOptions parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = numberOfThreads };

            Parallel.For(0, height, parallelOptions, y =>
            {
                for (int x = 0; x < width; x++)
                {
                   
                    float red = 0, green = 0, blue = 0;
                    float[] rgbw = { red, green, blue };
                    for (int m = -1; m <= 1; m++)
                    {      
                            for (int n = -1; n <= 1; n++)
                            {

                            int offsetX = x + m;
                            int offsetY = y + n;

                            // Ensure the offset is within bounds
                            offsetX = Math.Max(0, Math.Min(offsetX, width - 1));
                            offsetY = Math.Max(0, Math.Min(offsetY, height - 1));

                            Color pixelColor = sourcePixels[offsetX, offsetY];
                            float weight = matrix[m + 1, n + 1];
                            float[] tabw = { weight, weight, weight };
                            float[] rgb = { pixelColor.R, pixelColor.G, pixelColor.B };
                            ASMfuncmul(tabw, rgb, rgbw, factortable);
                            }
                        
                        
                    }
                    ASMfuncdiv(rgbw, factortable);


                    Color updatedColor = Color.FromArgb(255, (int)rgbw[0], (int)rgbw[1], (int)rgbw[2]);

                    // Update resultPixels using a lock to protect the critical section
                    lock (lockObject)
                    {
                        resultPixels[x, y] = updatedColor;
                    }
                }
            });

            BitmapData resultData = result.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            unsafe
            {
                byte* resultPtr = (byte*)resultData.Scan0.ToPointer();

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        byte* pixel = resultPtr + y * resultData.Stride + x * 4;
                        Color resultColor = resultPixels[x, y];

                        pixel[0] = resultColor.B;
                        pixel[1] = resultColor.G;
                        pixel[2] = resultColor.R;
                        pixel[3] = 255; // Set alpha to 255
                    }
                }
            }

            result.UnlockBits(resultData);

            return result;
        }

        public static float[] Flatten( float[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            float[] flattened = new float[rows * cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    flattened[i * cols + j] = matrix[i, j];
                }
            }

            return flattened;
        }
    }


}
    public class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public float ToFloat()
        {
            return (float)Numerator / Denominator;
        }

        public static Fraction Parse(string input)
        {
            string[] parts = input.Split('/');
            if (parts.Length == 2 && int.TryParse(parts[0], out int numerator) && int.TryParse(parts[1], out int denominator))
            {
                return new Fraction(numerator, denominator);
            }
            throw new FormatException("Invalid fraction format");
        }


        

    }



