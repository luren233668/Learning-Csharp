namespace Homework1;

// 定义形状接口
public interface IFigure
{
    // 计算面积
    double Area();
    // 判断形状是否合法
    bool IsLegal();
    // 打印形状的具体信息
    void PrintDetails();
}