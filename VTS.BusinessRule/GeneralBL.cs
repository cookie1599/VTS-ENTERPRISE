using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Reskrimsus.BusinessEntity;
//using System.Collections;
//using System.Data.Linq.SqlClient;
using System.Net;

namespace VTS.BusinessRule
{
    public sealed class GeneralBL : Base
    {
        public GeneralBL()
        {
        }
        ~GeneralBL()
        {
        }

        public String CreateRandom(int _length)
        {
            String _result = String.Empty;
            string _allowedChars = "1021812780479012474891047123863891274937540235043857389012713054713723837103479823489124934896755";
            Random randNum = new Random();
            char[] chars = new char[_length];
            int allowedCharCount = _allowedChars.Length;

            for (int i = 0; i < _length; i++)
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];

            _result = new string(chars);
            return _result;
        }

        public Boolean CheckExistFile(String _prmUrlFile)
        {
            Boolean _result = false;
            try
            {
                HttpWebRequest _request = (HttpWebRequest)WebRequest.Create(_prmUrlFile);
                HttpWebResponse _response = (HttpWebResponse)_request.GetResponse();
                _result = true;
            }
            catch
            {
            }
            return _result;
        }
    }
}
