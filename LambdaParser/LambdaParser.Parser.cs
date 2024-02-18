using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LambdaSyntaxTree;

namespace lambda_dsl.LambdaParser
{
    internal partial class LambdaParserParser
    {
        private NodeExpr _treeRoot;
        public LambdaParserParser() : base(null) { }

        public NodeExpr Parse(string s)
        {
            byte[] inputBuffer = System.Text.Encoding.Default.GetBytes(s);
            MemoryStream stream = new MemoryStream(inputBuffer);
            this.Scanner = new LambdaParserScanner(stream);
            this.Parse();
            return _treeRoot;
        }
    }
}
