namespace algorithms.sort;

class MergeSort
{
    public void msort(int[] arr, int p, int r)
    {
        if (p < r)
        {
            int q = (p + r) / 2;
            msort(arr, p, q);
            msort(arr, q+1, r);

            merge(arr, p, q, r);
        }
    }

    private void merge(int[] arr, int p, int q, int r)
    {
        // merges two sorted parts into one
        // can't sort in place, requires buffer     

        int[] left = new int[q-p+1];
        Array.Copy(arr, p, left, 0, q-p+1); // copy left sorted part

        int[] right = new int[r-q];
        Array.Copy(arr, q+1, right, 0, r-q); // copy right sorted part

        int li = 0, ri = 0, i = p;
        while(li < left.Length && ri < right.Length)
        {
            if(left[li] <= right[ri])
                arr[i++] = left[li++];
            else
                arr[i++] = right[ri++];
        }

        int[] tarr = null;
        int ti = 0;
        if(li < left.Length)
        {
            tarr= left;
            ti = li;
        }
        else if(ri < right.Length)
        {
            tarr= right;
            ti = ri;
        }
        if(tarr != null)
        {
            Array.Copy(tarr, ti, arr, i, tarr.Length - ti);
        }
    }
}