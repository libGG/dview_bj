// C,CPP_test.cpp : �������̨Ӧ�ó������ڵ㡣
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
char get_val(string &str,int i)//�������Ͳ�Ϊ����   
{  
    return str[i];  
}  
int main()  
{  
    string s("123456");  
    cout<<s<<endl;  
    char p;  
    p=get_val(s,2); //��Ϊ����get_val()����ֵ�������ã����Ա��븳ֵ��һ�����������ʹ�á�   
    cout<<p<<endl;  
	cout<<get_val(s,2)<<endl;
	cin.get();
    return 0;  
}  


