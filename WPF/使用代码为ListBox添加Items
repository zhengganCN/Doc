###使用代码为ListBox添加Items
####简单的显示字符串数据
1、XAML文件中有名为dataListBox的控件
<ListBox Name="dataListBox">
    
</ListBox>
2、.cs文件中的写如下代码完成对ListBox中Item的添加
string[] data = {"data1","data2","data3"};
dataListBox.ItemsSource=data;
####显示List对象列表数据
1、XAML文件中有名为dataListBox的控件
<ListBox Name="dataListBox">
    
</ListBox>
2、.cs文件中的写如下代码完成对ListBox中Item的添加
public class Employee{
    public int Id{get;set;}
    public string Name{get;set;}
    public int Age{get;set;}
}
List<Employee> employee=new List<Employee>(){
    new Employee(){Id=1,Name="tim",Age=22},
    new Employee(){Id=2,Name="kil",Age=26},
    new Employee(){Id=3,Name="wer",Age=28}
}
dataListBox.DisplayMemberPath="Name";
dataListBox.SelectedValuePath="Id";
dataListBox.ItemsSource=employee;

DisplayMemberPath这个属性告诉ListBox显示每条数据的哪个属性，换句话说，
ListBox会去调用这个属性值的ToString()方法，把得到的字符串放入一个
TextBlock(最简单的文本控件)，然后再把TextBlock包装进一个ListBoxltem里 。

ListBox的SelectedValuePath属性将与其SelectedValue属性配合使用。当你调用SelectedValue
属性时，ListBox先找到选中的Item所对应的数据对象，然后把SelectedValuePath的值当作数据对
象的属性名称并把这个属性的值取出来。

DisplayMemberPath和SelectedValuePath是两个相当简化的属性. DisplayMemberPath只能
显示简单的字符串，想用更加复杂的形式显示数据需要使用DataTemplate

####带图片的ListViewItem
    1、XAML文件中有名为imageListBox的控件
    <ListBox Name="musicListBox">
        <ListBox.ItemTemplate>
            <DataTemplate>
                <StackPanel Orientation="Horizontal">
                    <Image Height="40" Source="aixuexi_logo.png"></Image>
                    <TextBlock Text="{Binding Path=Id}" Width="30"></TextBlock>
                    <TextBlock Text="{Binding Path=Name}" Width="30"></TextBlock>
                    <TextBlock Text="{Binding Path=Age}" Width="30"></TextBlock>
                </StackPanel>
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
    2、C#代码
    List<Student> list = new List<Student>()
    {
        new Student(){Id=11,Name="timo",Age=20},
        new Student(){Id=21,Name="momo",Age=20},
        new Student(){Id=31,Name="lako",Age=20}
    };
    musicListBox.ItemsSource = list;
