using System;
using System.Linq;
using System.Collections.Generic;

using System.Data.Linq.SqlClient;

using VTS.BusinessEntity;
//using System.Web;

using System.Text;

using System.Data;
using System.Data.SqlClient;

using VTS.SystemConfig;
using Microsoft.Reporting.WebForms;













namespace VTS.BusinessRule
{
    public sealed class ReportBL : Base
    {
        public ReportBL()
        {
        }
        ~ReportBL()
        {
        }

        public ReportDataSource ReportVisitor(String _prmConnString)
        {
            ReportDataSource _result = new ReportDataSource();
            DataTable _dataTable = new DataTable();
            try
            {
                SqlConnection _conn = new SqlConnection(_prmConnString);
                SqlCommand _cmd = new SqlCommand();

                _cmd.CommandType = CommandType.Text;
                _cmd.Parameters.Clear();
                _cmd.Connection = _conn;
                _cmd.CommandTimeout = 180;
                _cmd.CommandText = "EXEC spVTS_CountDashboardVisitor";
                //_cmd.CommandText += "@BookRef ='" + _prmTransId + "'";

                SqlDataAdapter _da = new SqlDataAdapter();

                _da.SelectCommand = _cmd;
                _da.Fill(_dataTable);

                _result.Value = _dataTable;
                _result.Name = "DataSet1";
            }
            catch (Exception ex)
            {
            }

            return _result;
        }

        public ReportDataSource ReportAnswerPerMonth(String _prmConnString, String _prmStartDate, String _prmEndDate)
        {
            ReportDataSource _result = new ReportDataSource();
            DataTable _dataTable = new DataTable();
            try
            {
                SqlConnection _conn = new SqlConnection(_prmConnString);
                SqlCommand _cmd = new SqlCommand();

                _cmd.CommandType = CommandType.Text;
                _cmd.Parameters.Clear();
                _cmd.Connection = _conn;
                _cmd.CommandTimeout = 180;
                _cmd.CommandText = "EXEC spVTS_RptAnswerPerMonth ";
                _cmd.CommandText += "@StartDate ='" + _prmStartDate + "',";
                _cmd.CommandText += "@EndDate ='" + _prmEndDate + "'";

                SqlDataAdapter _da = new SqlDataAdapter();

                _da.SelectCommand = _cmd;
                _da.Fill(_dataTable);

                _result.Value = _dataTable;
                _result.Name = "DataSet1";
            }
            catch (Exception ex)
            {
            }

            return _result;
        }

        public ReportDataSource ReportSp_Visitor(String _prmConnString, String _prmStartDate, String _prmEndDate, String _prmType)
        {
            ReportDataSource _result = new ReportDataSource();
            DataTable _dataTable = new DataTable();
            try
            {
                SqlConnection _conn = new SqlConnection(_prmConnString);
                SqlCommand _cmd = new SqlCommand();

                _cmd.CommandType = CommandType.Text;
                _cmd.Parameters.Clear();
                _cmd.Connection = _conn;
                _cmd.CommandTimeout = 180;
                _cmd.CommandText = "EXEC sp_RptVisitor ";
                _cmd.CommandText += "@StartDate ='" + _prmStartDate + "',";
                _cmd.CommandText += "@EndDate ='" + _prmEndDate + "',";
                _cmd.CommandText += "@Type ='" + _prmType + "'";


                SqlDataAdapter _da = new SqlDataAdapter();

                _da.SelectCommand = _cmd;
                _da.Fill(_dataTable);

                _result.Value = _dataTable;
                _result.Name = "DataSet1";
            }
            catch (Exception ex)
            {
            }

            return _result;
        }

        public ReportDataSource ReportspVTS_RptAnswerPerThreeMonth(String _prmConnString)
        {
            ReportDataSource _result = new ReportDataSource();
            DataTable _dataTable = new DataTable();
            try
            {
                SqlConnection _conn = new SqlConnection(_prmConnString);
                SqlCommand _cmd = new SqlCommand();

                _cmd.CommandType = CommandType.Text;
                _cmd.Parameters.Clear();
                _cmd.Connection = _conn;
                _cmd.CommandTimeout = 180;
                _cmd.CommandText = "EXEC spVTS_RptAnswerPerThreeMonth ";
                //_cmd.CommandText += "@BookRef ='" + _prmTransId + "'";

                SqlDataAdapter _da = new SqlDataAdapter();

                _da.SelectCommand = _cmd;
                _da.Fill(_dataTable);

                _result.Value = _dataTable;
                _result.Name = "DataSet1";
            }
            catch (Exception ex)
            {
            }

            return _result;
        }

        public ReportDataSource ReportspVTS_RptGrafikQuestion(String _prmConnString, String _prmStartDate, String _prmEndDate)
        {
            ReportDataSource _result = new ReportDataSource();
            DataTable _dataTable = new DataTable();
            try
            {
                SqlConnection _conn = new SqlConnection(_prmConnString);
                SqlCommand _cmd = new SqlCommand();

                _cmd.CommandType = CommandType.Text;
                _cmd.Parameters.Clear();
                _cmd.Connection = _conn;
                _cmd.CommandTimeout = 180;
                _cmd.CommandText = "EXEC spVTS_RptGrafikQuestion ";
                _cmd.CommandText += "@StartDate ='" + _prmStartDate + "',";
                _cmd.CommandText += "@EndDate ='" + _prmEndDate + "'";

                SqlDataAdapter _da = new SqlDataAdapter();

                _da.SelectCommand = _cmd;
                _da.Fill(_dataTable);

                _result.Value = _dataTable;
                _result.Name = "DataSet1";
            }
            catch (Exception ex)
            {
            }

            return _result;
        }

        public ReportDataSource ReportspVTS_RptAnswerSatisfactionPerDivision(String _prmConnString, String _prmStartDate, String _prmEndDate)
        {
            ReportDataSource _result = new ReportDataSource();
            DataTable _dataTable = new DataTable();
            try
            {
                SqlConnection _conn = new SqlConnection(_prmConnString);
                SqlCommand _cmd = new SqlCommand();

                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.Parameters.Clear();
                _cmd.Connection = _conn;
                _cmd.CommandTimeout = 180;
                _cmd.CommandText = "spVTS_RptAnswerSatisfactionPerDivision";
                _cmd.Parameters.AddWithValue("@StartDate", _prmStartDate);
                _cmd.Parameters.AddWithValue("@EndDate", _prmEndDate);
                SqlDataAdapter _da = new SqlDataAdapter();

                _da.SelectCommand = _cmd;
                _da.Fill(_dataTable);

                _result.Value = _dataTable;
                _result.Name = "DataSet1";
            }
            catch (Exception ex)
            {
            }

            return _result;
        }

        public ReportDataSource ReportspVTS_RptPenyidik(String _prmConnString, String _prmPenyidikNumb, String _prmFgActive)
        {
            ReportDataSource _result = new ReportDataSource();
            DataTable _dataTable = new DataTable();
            try
            {
                SqlConnection _conn = new SqlConnection(_prmConnString);
                SqlCommand _cmd = new SqlCommand();

                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.Parameters.Clear();
                _cmd.Connection = _conn;
                _cmd.CommandTimeout = 180;
                _cmd.CommandText = "spVTS_RptPenyidik";
                _cmd.Parameters.AddWithValue("@PenyidikNumb", _prmPenyidikNumb);
                _cmd.Parameters.AddWithValue("@FgActive", _prmFgActive);
                SqlDataAdapter _da = new SqlDataAdapter();

                _da.SelectCommand = _cmd;
                _da.Fill(_dataTable);

                _result.Value = _dataTable;
                _result.Name = "DataSet1";
            }
            catch (Exception ex)
            {
            }

            return _result;
        }


        public ReportDataSource ReportspVTS_RptGrafikQuestion2(String _prmConnString)
        {
            ReportDataSource _result = new ReportDataSource();
            DataTable _dataTable = new DataTable();

            try
            {
                SqlConnection _conn = new SqlConnection(_prmConnString);
                SqlCommand _cmd = new SqlCommand();

                _cmd.CommandType = CommandType.Text;
                _cmd.Parameters.Clear();
                _cmd.Connection = _conn;
                //_cmd.Parameters.AddWithValue("@FgActive", "Y");
                //_cmd.CommandText = "SELECT * FROM  tMs_RekapProject where FgActive=@FgActive";
                _cmd.CommandText = "SELECT SUBSTRING(Remark, 1, 1)+' = ' AS Tipe, LTRIM(SUBSTRING(Remark, 3, LEN(Remark))) AS Ket FROM dbo.MsQuestionHd WHERE COALESCE(FgOptional, 'Y') = 'Y'";

                SqlDataAdapter _da = new SqlDataAdapter();
                _da.SelectCommand = _cmd;
                _da.Fill(_dataTable);
                _result.Value = _dataTable;
                _result.Name = "DataSet2";
            }
            catch (Exception ex)
            {

            }

            return _result;
        }


        public ReportDataSource ReportGetSP2HP(String _prmConnString, String _prmNOSP2HP, String _prmNOLP)
        {
            ReportDataSource _result = new ReportDataSource();
            DataTable _dataTable = new DataTable();
            try
            {
                SqlConnection _conn = new SqlConnection(_prmConnString);
                SqlCommand _cmd = new SqlCommand();

                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.Parameters.Clear();
                _cmd.Connection = _conn;
                _cmd.CommandTimeout = 180;
                _cmd.CommandText = "GetSP2HP";
                _cmd.Parameters.AddWithValue("@NOSP2HP", _prmNOSP2HP);
                _cmd.Parameters.AddWithValue("@NOLP", _prmNOLP);
                SqlDataAdapter _da = new SqlDataAdapter();

                _da.SelectCommand = _cmd;
                _da.Fill(_dataTable);

                _result.Value = _dataTable;
                _result.Name = "VTS_Development";
            }
            catch (Exception ex)
            {
            }

            return _result;
        }




    }
}
