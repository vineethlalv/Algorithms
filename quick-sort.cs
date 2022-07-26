namespace algorithms.sort;

class QuickSort
{
    public void qsort(int[] arr, int p, int r)
    {
        if(p < r)
        {
            int q = partition(arr, p, r);
            qsort(arr, p, q-1);
            qsort(arr, q+1, r);
        }
    }

    private int partition(int[] arr, int p, int r)
    {
        // select an element as pivot and move all lesser and equal to left and greater to right

        int q = r;
        int pivot = arr[r];

        for(int i = p; i < q; i++)
        {
            if(arr[i] > pivot)
            {
                int temp = arr[--q];
                arr[q] = arr[i];
                arr[i] = temp;
                --i;
            }
        }
        arr[r] = arr[q];
        arr[q] = pivot;

        return q;
    }
}