using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timeclock
{
    internal class Employemeneger
    {
        private static string _loginSQL = "declare @firstname varchar (20) = '' , @lastname varchar(20) =  '', @code INT,  @answer varchar(200);\r\n\r\n\r\nif exists (select * from employee where pesword2 = @pesword2)\r\n\tbegin\r\n\t\tSELECT @code = ( SELECT code from employee where pesword2 = @pesword2)\r\n\tend\r\nelse\r\n\tbegin \r\n     \t insert into employee values (@firstname,  @lastname,  @pesword2)\r\n\t\t select @code = @@IDENTITY\r\n\tend\r\n\r\n \r\n\r\n\r\nIF exists (select * from Passwords WHERE user1=@code)\r\n\tbegin\r\n\t\tif exists (select pesword From Passwords\r\n\t\t\t\t\tWHERE user1=@code AND pesword=@pesword\r\n\t\t\t\t\tAND active=1 )\r\n\t\t\t\tbegin\r\n\t\t\t\t\tif exists (select pesword From Passwords\r\n\t\t\t\t\tWHERE user1=@code AND pesword=@pesword\r\n\t\t\t\t\tAND active=1 AND  ExpiryDate>=getdate())\r\n\t\t\t\t\t\tbegin\r\n\t\t\t\t\t\t\tIF exists (SELECT * FROM timeclock\r\n\t\t\t\t\t\t\tWHERE user1=@code AND exits is null)\r\n\t\t\t\t\t\t\t\tbegin \t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\tUPDATE timeclock set exits=GETDATE()\r\n\t\t\t\t\t\t\t\t\tWHERE user1=@code AND exits is null;\r\n\t\t\t\t\t\t\t\t\tselect @answer='Exit time: ' + CONVERT (NVARCHAR, GETDATE(), 121);\r\n\t\t\t\t\t\t\t\tend\r\n\t\t\t\t\t\t\telse\r\n\t\t\t\t\t\t\t\tbegin\r\n\t\t\t\t\t\t\t\tINSERT INTO timeclock  VALUES ( GETDATE(), null, @code);\r\n\t\t\t\t\t\t\t\tselect @answer='Entry time: ' + CONVERT (NVARCHAR, GETDATE(), 121);\r\n\t\t\t\t\t\t\t\tend\r\n\t\t\t\t\t\tend\r\n\t\t\t\t\tELSE\r\n\t\t\t\t\t\tbegin\r\n\t\t\t\t\t\tselect @answer= 'you need to update your password';\r\n\t\t\t\t\t\tend\r\n\t\t\t\tend\r\n\t\tELSE\r\n\t\t\tbegin\r\n\t\t\tselect @answer = 'wrong password';\r\n\t\t\tend\r\n\tend\r\nELSE\r\n\tbegin\r\n\t\tINSERT INTO\tPasswords VALUES ( @pesword,\r\n\t\tDATEADD(day, 180, GETDATE()),\r\n\t\t1,@code)\r\n\t\tselect @answer= 'You created a worker and password';\r\n\tend\r\n\r\nselect @answer\r\n";
        private static string _changePasswordSQL = "declare\r\n@answer varchar(200)\r\n\r\n\r\nif exists (select * from employee where Employee.pesword2 = @id)\r\n\tbegin\r\n\t\tdeclare @code int = (select Employee.code from Employee where pesword2 = @id)\r\n\t\t\r\n\t\tIF @oldpass = (SELECT pesword FROM passwords WHERE user1 = @code)\r\n\t\t\tbegin\r\n\t\t\t\tif (@newpass = @confirm)\r\n\t\t\t\t\tbegin \r\n\t\t\t\t\t\tUPDATE passwords set pesword = @newpass;\r\n\t\t\t\t\t\tselect @answer = 'Your password has been successfully changed!'\r\n\t\t\t\t\tend\r\n\t\t\t\telse \r\n\t\t\t\t\tbegin\r\n\t\t\t\t\t\tselect @answer = 'The password does not match'\r\n\t\t\t\t\tend\t\t\r\n\t\t\tend\r\n\t\telse\r\n\t\t\tbegin \r\n\t\t\t\tselect @answer = 'Old password cannot be used'\r\n\t\t\tend\r\n\tend\r\n\t\r\nelse \r\n\tbegin\r\n\t\tselect @answer = 'The user does not exist'\r\n\tend\r\n\r\nselect @answer";
        public void doX()
        {
        }
        public static string Login(string id, string password)
        {
            // 1. Use the _loginSQL
            // 2. Execute SQL against DB
            string[] parameters = { "@pesword2", "@pesword" };
            string[] values = { id, password };

            // 3. Return response
            return Dbconnaction.runSQL(_loginSQL, parameters, values);
        }
        public static string ChangePassword(string id, string oldPass, string newPass, string confirmPass)
        {
            string[] parameters = { "@id", "@oldpass", "@newpass", "@confirm" };
            string[] values = { id, oldPass, newPass, confirmPass };

            // 1. Use the _loginSQL
            // 2. Execute SQL against DB
            // 3. Return response
            return Dbconnaction.runSQL(_changePasswordSQL, parameters, values);
        }
    }
    
}
