public class NestedListWeightSum {
	int sum;
	int level;
	public NestedListWeightSum(int sum, int level) {
		this.sum = 0;
		this.level = 0;
	}

	public int Solve(List<Node> nodes) {
		foreach(Node n in nodes) {
			sum += SolveR(n);
		}		 
		return sum;
	}

	private int SolveR(Node N) {
		// bc

		int s = 0;
		if(N.isInt()) {
			return level * N;		
		} else 	{
			foreach(Node n in N) {
				s += SolveR(n);
			}
			return s;
		}				
	}
}


public class Node {
	private bool isInt;
	private var;

	public Node(bool isInt, var n) {
		this.isInt = isInt'
		this.var = n
	}

	public bool isInt() {
		return isInt;
	}
}

//Test
/*
-[1]
-[[[[1]]]]
-[1,2,3]
-[1,2,[3]]
-[[1],2,3]
-[[1],[1]]
*/