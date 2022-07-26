namespace algorithms.sort;

class HeapSort
{    
    //  (binary) heap datastructure
    //
    //                9
    //            8        7
    //         9     5  4     3
    //       2   1 
    //
    // 
    //  | 9 | 8 | 7 | 6 | 5 | 4 | 3 | 2 | 1 |      => representation using an array
    //  --1---2---3---4---5---6---7---8---9--      -> index (1-based)
    //  
    // index of Root of a Node  = i/2
    // index of Left node of a Root  = 2*i
    // index of Right node of a Root = 2*i + 1
    //
    // 
    
    public void hsort(int[] arr)
    {
        buildMaxHeap(arr);  // build initial heap
        for(int i = arr.Length - 1; i > 0; i--)
        {
            int t = arr[i];
            arr[i] =  arr[0]; // the largest element in the heap
            arr[0] = t;

            maxHeapify(arr, i, 0); // get next largest element after decrementing heapsize
        }
    }

    private void buildMaxHeap(int[] arr)
    {
        // convert an array into heap format

        for (int i = arr.Length / 2 - 1; i >= 0; i--) // (arr.Length / 2 - 1) is Root of last element in the array
           maxHeapify(arr, arr.Length, i);
    }

    private void maxHeapify(int[] arr, int heapSize, int rootIndex)
    {
        // heap sort uses max-heap where largest element is the root

        int lefti  = rootIndex * 2 + 1;
        int righti = rootIndex * 2 + 2;

        int rootIndexTemp = rootIndex;
        if(lefti < heapSize && arr[rootIndexTemp] < arr[lefti])
            rootIndexTemp = lefti;
        if(righti < heapSize && arr[rootIndexTemp] < arr[righti])
            rootIndexTemp = righti;

        if(rootIndex != rootIndexTemp)
        {            
            int t = arr[rootIndex];
            arr[rootIndex] = arr[rootIndexTemp];
            arr[rootIndexTemp] = t;

            maxHeapify(arr, heapSize, rootIndexTemp); // bubble up largest element to top
        }
    }
}