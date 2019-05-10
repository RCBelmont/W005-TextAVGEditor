//============================
//Created By RCBelmont on 2019年4月30日
//Description 通用工具类
//============================


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RCBelmont.TAGEditor
{
        public class CommonUtils
    {
        //单例
        private static CommonUtils _instance;

        public static CommonUtils Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CommonUtils();
                }

                return _instance;
            }
        }

        #region Public Methon

        public ulong GetUID()
        {
            byte[] bytes = Guid.NewGuid().ToByteArray();
            return BitConverter.ToUInt64(bytes, 0);
        }

        #endregion
    }


}
