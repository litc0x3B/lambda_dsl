namespace LambdaSyntaxTree {

    abstract class NodeExpr 
    {
        public abstract NodeExpr Eval();
        public abstract NodeExpr Apply(NodeExpr arg);
        public abstract NodeExpr Substitute(NodeId id, NodeExpr expr);
        public abstract override string ToString();
    }

    class NodeAppl : NodeExpr 
    {
        private NodeExpr _left;
        private NodeExpr _right; 

        public NodeAppl(NodeExpr left, NodeExpr right)
        {
            _left = left;
            _right = right;
        }

        public override NodeExpr Eval()
        {
            _left = _left.Eval();
            _right = _right.Eval();
            return _left.Apply(_right);
        }

        public override NodeExpr Apply(NodeExpr arg)
        {
            return new NodeAppl(this, arg);
        }

        public override NodeExpr Substitute(NodeId id, NodeExpr expr)
        {
            _left = _left.Substitute(id, expr);
            _right = _right.Substitute(id, expr);
            return this;
        }

        public override string ToString()
        {
            string rightString = _right.ToString();
            if (_right is NodeAppl)
            {
                rightString = '(' + rightString + ')';
            }

            return _left.ToString() + rightString;
        }
    }

    class NodeAbstr : NodeExpr 
    {
        private NodeId _id;
        private NodeExpr _expr;

        public NodeAbstr(NodeId id, NodeExpr expr)
        {
            _id = id;
            _expr = expr;
        }

        public override NodeExpr Eval()
        {
            _expr = _expr.Eval();
            return this;
        }

        public override NodeExpr Apply(NodeExpr arg)
        {
            _expr = _expr.Substitute(_id, arg);
            return _expr;
        }

        public override NodeExpr Substitute(NodeId id, NodeExpr expr)
        {
            _expr = _expr.Substitute(id, expr);
            return this;
        }

        public override string ToString()
        {
            return "(\\" + _id.ToString() + '.' + _expr.ToString() + ')';
        }
    }

    class NodeId : NodeExpr 
    {
        private char _name;

        public override NodeExpr Eval()
        {
            return this;
        }

        public override NodeExpr Apply(NodeExpr arg)
        {
            return new NodeAppl(this, arg);
        }

        public override NodeExpr Substitute(NodeId id, NodeExpr expr)
        {
            if (id._name == this._name)
            {
                return expr;
            }

            return this;
        }

        public NodeId(char name) 
        {
            _name = name;
        }

        public override string ToString()
        {
            return _name.ToString();
        }
    }
}
