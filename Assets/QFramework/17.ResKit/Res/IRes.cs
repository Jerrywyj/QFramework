﻿/****************************************************************************
 * Copyright (c) 2017 snowcold
 * Copyright (c) 2017 liangxie
 * 
 * http://liangxiegame.com
 * https://github.com/liangxiegame/QFramework
 * https://github.com/liangxiegame/QSingleton
 * https://github.com/liangxiegame/QChain
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 ****************************************************************************/

namespace QFramework
{
    using System;
    
    public class ResState
    {
        public const short Waiting = 0;
        public const short Loading = 1;
        public const short Ready = 2;
        public const short Disposing = 4;

        public static bool IsReady(short value)
        {
            return value == Ready;
        }
    }

    public class ResType
    {
        public const short AssetBundle = 0;
        public const short ABAsset = 1;
        public const short ABScene = 2;
        public const short Internal = 3;
        public const short NetImageRes = 4;
        public const short LocalImageRes = 5;
    }

    public interface IRes : IRefCounter, IPoolType, IEnumeratorTask
    {
        string AssetName
        {
            get;
        }

        string OwnerBundleName { get; }

        short State
        {
            get;
            set;
        }

        UnityEngine.Object Asset
        {
            get;
            set;
        }

        object RawAsset
        {
            get;
        }

        float Progress
        {
            get;
        }

        void RegisteResListener(Action<bool, IRes> listener);
        void UnRegisteResListener(Action<bool, IRes> listener);

        bool UnloadImage(bool flag);

        bool LoadSync();

        void LoadAsync();

        string[] GetDependResList();

        bool IsDependResLoadFinish();

        bool ReleaseRes();

        void AcceptLoaderStrategySync(IResLoader loader, IResLoaderStrategy strategy);
        void AcceptLoaderStrategyAsync(IResLoader loader, IResLoaderStrategy strategy);
    }
}
