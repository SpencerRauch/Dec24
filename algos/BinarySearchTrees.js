/**
 * Class to represent a Node in a Binary Search Tree (BST).
 */
class BSTNode {
    /**
     * Constructs a new instance of a BST node.
     * @param {number} data The integer to store in the node.
     */
    constructor(data) {
        this.data = data;
        /**
         * These properties are how this node is connected to other nodes to form
         * the tree. Similar to .next in a SinglyLinkedList except a BST node can
         * be connected to two other nodes. To start, new nodes will not be
         * connected to any other nodes, these properties will be set after
         * the new node is instantiated.
         *
         * @type {BSTNode|null}
         */
        this.left = null;
        /** @type {BSTNode|null} */
        this.right = null;
    }
}
/**
 * Represents an ordered tree of nodes where the data of left nodes are <= to
 * their parent and the data of nodes to the right are > their parent's data.
 */
class BinarySearchTree {
    constructor() {
        /**
         * Just like the head of a linked list, this is the start of our tree which
         * branches downward from here.
         *
         * @type {BSTNode|null}
         */
        this.root = null;
    }
    /**
     * Determines if this tree is empty.
     * - Time: O(?).
     * - Space: O(?).
     * @returns {boolean} Indicates if this tree is empty.
     */
    isEmpty() {
        //Your code here
        return this.root == null;
    }
    /**
     * Retrieves the smallest integer data from this tree or null if tree is empty.
     * - Time: O(?).
     * - Space: O(?).
     * @param {Node} current The node that is currently accessed from the tree as
     *    the tree is being traversed.
     * @returns {number} The smallest integer from this tree.
     */
    min(current = this.root) {
        if (this.isEmpty()) return null;
        while (current.left) {
            current = current.left;
        }
        return current.data;
    }
    /**
     * Retrieves the smallest integer data from this tree or null if tree is empty.
     * - Time: O(?).
     * - Space: O(?).
     * @param {Node} current The node that is currently accessed from the tree as
     *    the tree is being traversed.
     * @returns {number} The smallest integer from this tree.
     */
    minRecursive(current = this.root) {
        if (current == null) return null;
        if (current.left == null) return current.data;
        return this.minRecursive(current.left);
    }
    /**
     * Retrieves the largest integer data from this tree or null if tree is empty.
     * - Time: O(?).
     * - Space: O(?).
     * @param {Node} current The node that is currently accessed from the tree as
     *    the tree is being traversed.
     * @returns {number} The largest integer from this tree.
     */
    max(current = this.root) {
        if (this.isEmpty()) return null;
        while (current.right) {
            current = current.right;
        }
        return current.data;
    }
    /**
     * Retrieves the largest integer data from this tree or null if tree is empty.
     * - Time: O(?).
     * - Space: O(?).
     * @param {Node} current The node that is currently accessed from the tree as
     *    the tree is being traversed.
     * @returns {number} The largest integer from this tree.
     */
    maxRecursive(current = this.root) {
        if (current == null) return null;
        if (current.right == null) return current.data;
        return this.maxRecursive(current.right);
    }
    // Logs this tree horizontally with the root on the left.
    print(node = this.root, spaceCnt = 0, spaceIncr = 10) {
        if (!node) {
            return;
        }
        spaceCnt += spaceIncr;
        this.print(node.right, spaceCnt);
        console.log(
            " ".repeat(spaceCnt < spaceIncr ? 0 : spaceCnt - spaceIncr) +
            `${node.data}`
        );
        this.print(node.left, spaceCnt);
    }
    /**
     * Determines if this tree contains the given searchVal.
     * - Time: O(?).
     * - Space: O(?).
     * @param {number} searchVal The number to search for in the node's data.
     * @returns {boolean} Indicates if the searchVal was found.
     */
    contains(searchVal) {
        //Your code here
        if (this.isEmpty()) return false;
        let runner = this.root;
        while (runner) {
            if (runner.data == searchVal) return true;
            if (runner.data > searchVal) runner = runner.left;
            else runner = runner.right;
        }
        return false;
    }

    /**
     * Determines if this tree contains the given searchVal.
     * - Time: O(?).
     * - Space: O(?).
     * @param {number} searchVal The number to search for in the node's data.
     * @returns {boolean} Indicates if the searchVal was found.
     */
    containsRecursive(searchVal, current = this.root) {
        //Your code here
        if (current == null) return false;
        if (current.data == searchVal) return true;
        if (searchVal < current.data) return this.containsRecursive(searchVal, current.left);
        return this.containsRecursive(searchVal, current.right);
    }

    /**
     * Calculates the range (max - min) from the given startNode.
     * - Time: O(?).
     * - Space: O(?).
     * @param {Node} startNode The node to start from to calculate the range.
     * @returns {number|null} The range of this tree or a sub tree depending on if the
     *    startNode is the root or not.
     */
    range(startNode = this.root) {
        return this.max() - this.min();
    }

    // https://www.cs.usfca.edu/~galles/visualization/BST.html
    /**
     * Inserts a new node with the given newVal in the right place to preserve
     * the order of this tree.
     * - Time: O(?).
     * - Space: O(?).
     * @param {number} newVal The data to be added to a new node.
     * @returns {BinarySearchTree} This tree.
     */
    insert(newVal) {
        //your code here
        let newNode = new BSTNode(newVal);
        if (this.isEmpty()) {
            this.root = newNode;
            return this;
        }
        let runner = this.root;
        while (true) {
            if (newVal < runner.data) {
                if (!runner.left) {
                    runner.left = newNode;
                    return this;
                }
                runner = runner.left;
            } else {
                if (!runner.right) {
                    runner.right = newNode;
                    return this;
                }
                runner = runner.right;
            }
        }
    }

    /**
     * Inserts a new node with the given newVal in the right place to preserve
     * the order of this tree.
     * - Time: O(?).
     * - Space: O(?).
     * @param {number} newVal The data to be added to a new node.
     * @param {Node} curr The node that is currently accessed from the tree as
     *    the tree is being traversed.
     * @returns {BinarySearchTree} This tree.
     */
    insertRecursive(newVal, curr = this.root) {
        //your code here
        if (this.isEmpty()) {
            this.root = new BSTNode(newVal);
            return this;
        }
        if (newVal < curr.data) {
            if (!curr.left) {
                curr.left = new BSTNode(newVal);
                return this;
            }
            return this.insertRecursive(newVal, curr.left);
        }
        if (!curr.right) {
            curr.right = new BSTNode(newVal);
            return this;
        }
        return this.insertRecursive(newVal, curr.right);
    }

    /**
     * DFS Inorder: (Left, CurrNode, Right)
     * Converts this BST into an array following Depth First Search inorder.
     * See debugger call stack to help understand the recursion.
     * Example on the fullTree var:
     * [4, 10, 12, 15, 18, 22, 24, 25, 31, 35, 44, 50, 66, 70, 90]
     * @param {Node} node The current node during the traversal of this tree.
     * @param {Array<number>} vals The data that has been visited so far.
     * @returns {Array<number>} The vals in DFS Preorder once all nodes visited.
     */
    toArrInorder(node = this.root, vals = []) {
        //Your code here
        if (!node) return vals;
        this.toArrInorder(node.left, vals);
        vals.push(node.data);
        this.toArrInorder(node.right, vals);
        return vals;
    }

    /**
     * DFS Preorder: (CurrNode, Left, Right)
     * Converts this BST into an array following Depth First Search preorder.
     * Example on the fullTree var:
     * [25, 15, 10, 4, 12, 22, 18, 24, 50, 35, 31, 44, 70, 66, 90]
     * @param {Node} node The current node during the traversal of this tree.
     * @param {Array<number>} vals The data that has been visited so far.
     * @returns {Array<number>} The vals in DFS Preorder once all nodes visited.
     */
    toArrPreorder(node = this.root, vals = []) {
        //Your code here
        if (!node) return vals;
        vals.push(node.data);
        this.toArrPreorder(node.left, vals);
        this.toArrPreorder(node.right, vals);
        return vals;
    }


    /**
     * DFS Postorder (Left, Right, CurrNode)
     * Converts this BST into an array following Depth First Search postorder.
     * Example on the fullTree var:
     * [4, 12, 10, 18, 24, 22, 15, 31, 44, 35, 66, 90, 70, 50, 25]
     * @param {Node} node The current node during the traversal of this tree.
     * @param {Array<number>} vals The data that has been visited so far.
     * @returns {Array<number>} The vals in DFS Preorder once all nodes visited.
     */
    toArrPostorder(node = this.root, vals = []) {
        // Your code here 
        if (!node) return vals;
        this.toArrPostorder(node.left, vals);
        this.toArrPostorder(node.right, vals);
        vals.push(node.data);
        return vals;
    }


    /**
         * BFS order: horizontal rows top-down left-to-right.
         * Converts this BST into an array following Breadth First Search order.
         * Example on the fullTree var:
         * [25, 15, 50, 10, 22, 35, 70, 4, 12, 18, 24, 31, 44, 66, 90]
         * @param {Node} current The current node during the traversal of this tree.
         * @returns {Array<number>} The data of all nodes in BFS order.
         */
    toArrLevelorder(current = this.root) {
        //array to hold values
        const vals = [];
        //array to hold next node to process
        const queue = [];

        //if current node exists, add it to the queue to start 
        if (current) queue.push(current)
        
        //as long as there is a node in the queue
        while (queue.length > 0) {
            //pull out the first node
            let node = queue.shift();
            //process its data
            vals.push(node.data);
            //if it has children, add them to the queue
            if (node.left) queue.push(node.left);
            if (node.right) queue.push(node.right);
        }
        return vals;
    }


}


const fullTree = new BinarySearchTree();
fullTree
    .insert(25)
    .insert(15)
    .insert(10)
    .insert(22)
    .insert(4)
    .insert(12)
    .insert(18)
    .insert(24)
    .insert(50)
    .insert(35)
    .insert(70)
    .insert(31)
    .insert(44)
    .insert(66)
    .insert(90);

/* fullTree
                root
            <-- 25 -->
          /            \
        15             50
      /    \         /    \
    10     22      35     70
  /   \   /  \    /  \   /  \
4    12  18  24  31  44 66  90

*/

console.log(fullTree.toArrLevelorder(), "\nshould be \n [25, 15, 50, 10, 22, 35, 70, 4, 12, 18, 24, 31, 44, 66, 90]"); 