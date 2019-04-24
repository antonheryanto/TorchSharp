﻿using System;
using System.Runtime.InteropServices;
using TorchSharp.Tensor;

namespace TorchSharp.NN
{
    /// <summary>
    /// Class maintaing the supported loss functions.
    /// </summary>
    public class LossFunction
    {
        [DllImport("libTorchSharp")]
        extern static IntPtr THSNN_lossBCE(IntPtr srct, IntPtr trgt, IntPtr wgt, long reduction);

        public static TorchTensor BCE<T, U>(TorchTensor src, TorchTensor target, TorchTensor? weigths = null, Reduction reduction = Reduction.Mean)
        {
            return new TorchTensor(THSNN_lossBCE(src.Handle, target.Handle, weigths?.Handle ?? IntPtr.Zero, (long)reduction));
        }

        [DllImport("libTorchSharp")]
        extern static IntPtr THSNN_lossMSE(IntPtr srct, IntPtr trgt, long reduction);

        public static TorchTensor MSE(TorchTensor src, TorchTensor target, Reduction reduction = Reduction.Mean)
        {
            return new TorchTensor(THSNN_lossMSE(src.Handle, target.Handle, (long)reduction));
        }

        [DllImport("libTorchSharp")]
        extern static IntPtr THSNN_lossNLL(IntPtr srct, IntPtr trgt, IntPtr wgt, long reduction);

        public static TorchTensor NLL(TorchTensor src, TorchTensor target, TorchTensor? weigths = null, Reduction reduction = Reduction.Mean)
        {
            return new TorchTensor(THSNN_lossNLL(src.Handle, target.Handle, weigths?.Handle ?? IntPtr.Zero, (long)reduction));
        }

        [DllImport("libTorchSharp")]
        extern static IntPtr THSNN_lossPoissonNLL(IntPtr srct, IntPtr trgt, bool logInput, bool full, float eps, long reduction);

        public static TorchTensor PoissonNLL(TorchTensor src, TorchTensor target, bool logInput = true, bool full = false, float eps = 1e-8f, Reduction reduction = Reduction.Mean)
        {
            return new TorchTensor(THSNN_lossPoissonNLL(src.Handle, target.Handle, logInput, full, eps, (long)reduction));
        }
    }

    public enum Reduction : long
    {
        None = 0,
        Mean = 1,
        Sum = 2
    }
}
