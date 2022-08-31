namespace algorithms.sort;

class IthOrderStatistics
{
    public int ithSmallest(int[] arr, int i, int p, int r) // [p, r)
    {
        (int gePivotStart, int eqPivotEnd) q;

        int pivot = getPivot(arr, p, r);
        q = partition(arr, p, r, pivot);

        if (i > q.gePivotStart && i <= q.eqPivotEnd)
            return arr[q.Item2];
        
        if (q.gePivotStart >= i)
            return ithSmallest(arr, i, p, q.gePivotStart + 1);
        else
            return ithSmallest(arr, i, q.eqPivotEnd + 1, r);
    }

    private int getPivot(int[] arr, int p, int r) // [p, r)
    {
        // non randomized way to find pivot 
        // this way guarantees O(n) worst case runtime

        if (p >= r)
            return arr[p];

        // group array elements by 5 and find median of each group
        int[] medians = new int[(r - p + 4) / 5];
        int j = 0;
        for(int i = p; i < r; i+=5)
        {
            int k = i + 4;
            if (k > r)
                k = r-1;
            
            int[] group = new int[k-i+1];
            Array.Copy(arr, i, group, 0, k-i+1);
            new InsertionSort().isort(group);    // insertion sort efficient for very small array
            medians[j++] = group[group.Length / 2];
        }

        // recursively to find median of whole array
        return getPivot(medians, 0, medians.Length - 1);
    }

    private (int, int) partition(int[] arr, int p, int r, int pivot)
    {
        // rearrange array as => (less-than-pivot) | (equal-to-pivot) | (greater-than-pivot)
        //                                         |q               q_|

        if (p < r)
        {
            int t;
            int q = p - 1;     // q pointing to first element equal to or greater than pivot
            int q_ = q;        // q_ pointing to last element equal to pivot
            for (int i = p; i < r; i++)
            {
                if (arr[i] < pivot)
                {
                    t = arr[++q];
                    ++q_;
                    if (t == pivot)
                    {
                        t = arr[q_];
                        arr[q_] = pivot;
                    }
                    arr[q] = arr[i];
                    arr[i] = t;
                }
                else if (arr[i] == pivot)
                {
                    t = arr[++q_];
                    arr[q_] = arr[i];
                    arr[i] = t;
                }
            }

            return (q, q_);
        }
        else
            return (p - 1, r);
    }
}
