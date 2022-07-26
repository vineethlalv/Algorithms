namespace algorithms.sort;

class InsertionSort
{
    public void isort(int[] arr)
    {
        for(int i = 0; i < arr.Length; i++)
        {
            // keep one end of an array sorted, with each iteration insert the element into sorted position
            int e = arr[i];
            int j = i - 1;
            while(j >= 0 && arr[j] > e)
            {
                arr[j+1] = arr[j];
                --j;
            }
            arr[j+1] = e;
        }
    }
}