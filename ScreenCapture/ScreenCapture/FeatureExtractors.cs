﻿using ImageProcessModule.ProcessingClass;
using System;
using System.Collections.Generic;
using System.IO;
using Tesseract;
using RedisEndpoint;

namespace ScreenCapture
{
    public class FeatureExtractors
    {
        public readonly static string SolutionRoot = Path.GetFullPath(Path.Combine(
    AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\.."));

        /// Initialize Tesseract object
        /// Remember to add tessdata directory
        protected static TesseractEngine tesseractEngine;
        protected static Publisher publisher = new Publisher("localhost", 6380);
        protected List<ImageProcess> ImageProcessesList = new List<ImageProcess>();
        protected FeatureExtractors() { }

        public static FeatureExtractors InitFeatureExtractor(int gameID, string[] outlets)
        {
            switch (gameID)
            {
                case 1:
                    tesseractEngine = new TesseractEngine(Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory), "HalfLife", EngineMode.Default);
                    return new HLA(outlets[0], outlets[1]);
                case 2:
                    tesseractEngine = new TesseractEngine(Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory), "KomuB", EngineMode.Default);
                    return new PC2(outlets[0]);
                case 3:
                    tesseractEngine = new TesseractEngine(Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory), "KomuB", EngineMode.Default);
                    return new BF1(outlets[0], outlets[1], outlets[2]);

                //Work In Progress
                //case 4:
                //    return new GR();
                default:
                    throw new NotImplementedException("Invalid gameID");
            }
        }
    }
}