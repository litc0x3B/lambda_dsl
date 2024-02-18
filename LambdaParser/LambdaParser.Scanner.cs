using System;
using System.Collections.Generic;
using System.Text;


namespace lambda_dsl.LambdaParser
{
    internal partial class LambdaParserScanner
    {

        // void GetNumber()
        // {
        //     yylval.s = yytext;
        //     yylval.n = int.Parse(yytext);
        // }


        void GetChar()
        {
            yylval.Id = yytext[0];
        }

		public override void yyerror(string format, params object[] args)
		{
			base.yyerror(format, args);
			Console.WriteLine(format, args);
			Console.WriteLine();
		}
    }
}
