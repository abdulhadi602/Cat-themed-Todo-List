using System;


[Serializable]
public class Data
{
   public Data(String Text,int TaskId)
    {
        this.Text = Text;
        this.TaskId = TaskId;
    }
    public String Text;
    public int TaskId;
}
