/**
 * https://www.cs.usfca.edu/~galles/visualization/Heap.html
 * Class to represent a MinHeap which is a Priority Queue optimized for fast
 * retrieval of the minimum value. It is implemented using an array but it is
 * best visualized as a tree structure where each 'node' has left and right
 * children except the 'node' may only have a left child.
 * - parent is located at: Math.floor(i / 2);
 * - left child is located at: i * 2
 * - right child is located at: i * 2 + 1
 */
class MinHeap {
    constructor() {
        /**
         * 0th index not used, so null is a placeholder. Not using 0th index makes
         * calculating the left and right children's index cleaner.
         * This also effectively makes our array start at index 1.
         */
        this.heap = [null];
    }

    //helper functions for finding parent / children of an index
    idxOfParent(index) {
        return Math.floor(index / 2);
    }

    // currentIdex
    // parentOfCurrent = this.idxOfParent(currentIdx)

    idxOfLeftChild(index) {
        return index * 2;
    }

    idxOfRightChild(index) {
        return index * 2 + 1;
    }

    /**
     * Retrieves the top (minimum number) in the heap without removing it.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {?number} Null if empty.
     */
    top() { 
        //your code here 
        return this.heap[1] ? this.heap[1] : null
    }

    /**
     * Inserts a new number into the heap and maintains the heaps order.
     * 1. Push new num to back of the heap array.
     * 2. Iteratively swap the new num with it's parent while it is smaller than
     *    it's parent.
     * - Time: O(log n) logarithmic due to shiftUp / iterative swapping.
     * - Space: O(1) constant.
     * @param {number} num The num to add.
     */
    insert(num) { 
        //add item to heap
        this.heap.push(num)

        // get index of newly added value
        let currentIdx = this.heap.length-1;
        // get index of newly added value's parent
        let parentIdx = this.idxOfParent(currentIdx);

        //while the parent is within the heap and the child is smaller
        while(parentIdx >= 1 && this.heap[currentIdx] < this.heap[parentIdx]){
            //swap child and parent
            let temp = this.heap[currentIdx]
            this.heap[currentIdx] = this.heap[parentIdx]
            this.heap[parentIdx] = temp

            //reset to check swapped value against new parent
            currentIdx = parentIdx
            parentIdx = this.idxOfParent(currentIdx)
        }
        return this
    }

    /**
     * Logs the tree horizontally with the root on the left and the index in
     * parenthesis using reverse inorder traversal.
     */
    printHorizontalTree(parentIdx = 1, spaceCnt = 0, spaceIncr = 10) {
        if (parentIdx > this.heap.length - 1) {
            return;
        }

        spaceCnt += spaceIncr;
        this.printHorizontalTree(parentIdx * 2 + 1, spaceCnt);

        console.log(
            " ".repeat(spaceCnt < spaceIncr ? 0 : spaceCnt - spaceIncr) +
            `${this.heap[parentIdx]} (${parentIdx})`
        );

        this.printHorizontalTree(parentIdx * 2, spaceCnt);
    }
    /**
     * Extracts the min num from the heap and then re-orders the heap to
     * maintain order so the next min is ready to be extracted.
     * 1. Save the first node to a temp var.
     * 2. Pop last node off and set idx1 equal to the popped value.
     * 3. Iteratively swap the old last node that is now at idx1 with it's
     *    smallest child IF the smallest child is smaller than it.
     * - Time: O(log n) logarithmic due to shifting down.
     * - Space: O(1) constant.
     * @returns {?number} The min number or null if empty.
    */
    extract() { 
        //your code here
    }
}


let testHeap = new MinHeap();

testHeap.insert(10);
testHeap.insert(7);
testHeap.insert(3);
testHeap.insert(4);
testHeap.insert(5);
testHeap.printHorizontalTree()


console.log("\n\n********\n\n");
console.log("extracted: ", testHeap.extract())
testHeap.printHorizontalTree();

console.log("\n\n********\n\n");
console.log("extracted: ",testHeap.extract())
testHeap.printHorizontalTree();