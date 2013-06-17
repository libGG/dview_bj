// C,CPP_test.cpp : 定义控制台应用程序的入口点。
//

//#include "stdafx.h"
//
//
//int _tmain(int argc, _TCHAR* argv[])
//{
//	return 0;
//}
#include<iostream>   
#include<string>   
using namespace std;  
char get_val(string &str,int i)//返回类型不为引用   
{  
    return str[i];  
}  
int main()  
{  
    string s("123456");  
    cout<<s<<endl;  
    char p;  
    p=get_val(s,2); //因为函数get_val()返回值不是引用，所以必须赋值给一个变量后才能使用。   
    cout<<p<<endl;  
	cout<<get_val(s,2)<<endl;
	cin.get();
    return 0;  
}  


