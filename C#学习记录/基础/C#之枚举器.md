# 枚举器

    string[] names=new string[5];
    public IEnumerator<string> GetEnumerator(){
        for(int i=0;i<names.length;i++>){
            yield return names[i];
        }
    }