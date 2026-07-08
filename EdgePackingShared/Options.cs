using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinanceManagement.Data
{
    public class Options
    {
        public class SessionNames
        {
            public static readonly string F_CustomerMaster = "F_CustomerMaster";
            public static readonly string CustomerName = "CustomerName";
            public static readonly string CompanyName = "CompanyName";
            public static readonly string CompanyAddress = "CompanyAddress";
            public static readonly string MobileNo = "MobileNo";
            public static readonly string Email = "Email";
            public static readonly string Password = "Password";
            public static readonly string LastLogin = "LastLogin";
            public static readonly string IsLogin = "IsLogin";
            public static readonly string ExcelHeader = "ExcelHeader";
            public static readonly string F_CompanyMaster = "F_CompanyMaster";
            
            #region Reporting Session

            public static readonly string ReportType = "ReportType";
            public static readonly string ReportParam = "ReportParam";
            public static readonly string ReportHeader = "ReportHeader";
            public static readonly string SendPrint = "SendPrint";

            #endregion
        }


        public static decimal F_CustomerMaster
        {
            get
            {
                object obj = HttpContext.Current.Session[SessionNames.F_CustomerMaster];
                return obj == null ? 0 : (decimal)obj;
            }
            set
            {
                HttpContext.Current.Session[SessionNames.F_CustomerMaster] = value;
            }
        }

        public static string CustomerName
        {
            get
            {
                object obj = HttpContext.Current.Session[SessionNames.CustomerName];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                HttpContext.Current.Session[SessionNames.CustomerName] = value;
            }
        }

        public static string F_CompanyMaster
        {
            get
            {
                object obj = HttpContext.Current.Session[SessionNames.F_CompanyMaster];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                HttpContext.Current.Session[SessionNames.F_CompanyMaster] = value;
            }
        }

        public static string CompanyName
        {
            get
            {
                object obj = HttpContext.Current.Session[SessionNames.CompanyName];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                HttpContext.Current.Session[SessionNames.CompanyName] = value;
            }
        }

        public static string CompanyAddress
        {
            get
            {
                object obj = HttpContext.Current.Session[SessionNames.CompanyAddress];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                HttpContext.Current.Session[SessionNames.CompanyAddress] = value;
            }
        }

        public static decimal MobileNo
        {
            get
            {
                object obj = HttpContext.Current.Session[SessionNames.MobileNo];
                return obj == null ? 0 : (decimal)obj;
            }
            set
            {
                HttpContext.Current.Session[SessionNames.MobileNo] = value;
            }
        }

        public static string Email
        {
            get
            {
                object obj = HttpContext.Current.Session[SessionNames.Email];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                HttpContext.Current.Session[SessionNames.Email] = value;
            }
        }

        public static string Password
        {
            get
            {
                object obj = HttpContext.Current.Session[SessionNames.Password];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                HttpContext.Current.Session[SessionNames.Password] = value;
            }
        }

        public static string LastLogin
        {
            get
            {
                object obj = HttpContext.Current.Session[SessionNames.LastLogin];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                HttpContext.Current.Session[SessionNames.LastLogin] = value;
            }
        }

        public static Boolean IsLogin
        {
            get
            {
                object obj = HttpContext.Current.Session[SessionNames.IsLogin];
                return obj == null ? false : (Boolean)obj;
            }
            set
            {
                HttpContext.Current.Session[SessionNames.IsLogin] = value;
            }
        }

        public static string ExcelHeader
        {
            get
            {
                object obj = HttpContext.Current.Session[SessionNames.ExcelHeader];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                HttpContext.Current.Session[SessionNames.ExcelHeader] = value;
            }
        }

        public static string ConnStr
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["InnConnectionString"].ConnectionString;
            }
        }
        private static string connectionStringName;

        public static string ConnectionStringName
        {
            get
            {
                if (string.IsNullOrEmpty(connectionStringName))
                {
                    connectionStringName = "InnConnectionString";
                }
                return connectionStringName;
            }
            set
            {
                connectionStringName = value;
            }
        }

        public static string ConnectionString
        {
            get
            {
                string connStr = "";
                try
                {
                    connStr = ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
                }
                catch
                {
                    connStr = string.Empty;
                }
                return connStr;
            }
        }
        #region Report

        public static decimal ReportType
        {
            get
            {
                object obj = HttpContext.Current.Session[SessionNames.ReportType];
                return obj == null ? 0 : (decimal)obj;
            }
            set
            {
                HttpContext.Current.Session[SessionNames.ReportType] = value;
            }
        }

        public static Object ReportParam
        {
            get
            {
                object obj = HttpContext.Current.Session[SessionNames.ReportParam];
                return obj == null ? null : obj;
            }
            set
            {
                HttpContext.Current.Session[SessionNames.ReportParam] = value;
            }
        }

        public static String ReportHeader
        {
            get
            {
                object obj = HttpContext.Current.Session[SessionNames.ReportHeader];
                return obj == null ? "" : (String)obj;
            }
            set
            {
                HttpContext.Current.Session[SessionNames.ReportHeader] = value;
            }
        }

        public static Boolean SendPrint
        {
            get
            {
                object obj = HttpContext.Current.Session[SessionNames.SendPrint];
                return obj == null ? false : (Boolean)obj;
            }
            set
            {
                HttpContext.Current.Session[SessionNames.SendPrint] = value;
            }
        }

        #endregion
        public static bool ValidateLogin(String UserName, String UserPass, out String ErrorMsg)
        {
            bool ReturnValue = false;
            Options.IsLogin = false;
            ErrorMsg = "Invalid Login";

            SqlParameter[] param = {
                                        new SqlParameter("UserName", UserName),
                                        new SqlParameter("UserPassword", UserPass)
                                    };
            SqlConnection con = new SqlConnection(ConnStr);
            SqlCommand cmd = new SqlCommand("ValidateLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(param);
            con.Open();
            SqlDataReader Dr = cmd.ExecuteReader();
            if (Dr.Read())
            {
                Options.IsLogin = true;
                Options.CustomerName = Dr["CustomerName"].ToString();
                Options.F_CustomerMaster = Convert.ToDecimal(Dr["Id"]);
                Options.CompanyName = Dr["companyname"].ToString();
                Options.CompanyAddress = Dr["CompanyAddress"].ToString();
                Options.MobileNo = Convert.ToDecimal(Dr["MobileNo"]);
                Options.Email = Dr["Email"].ToString();
                Options.Password = Dr["Password"].ToString();
                Options.LastLogin = Dr["LastLogin"].ToString();
                Options.F_CompanyMaster = Dr["F_CompanyMaster"].ToString();
                ReturnValue = true;
            }
            return ReturnValue;
        }
    }
}