#include "gdal/gdal.h"
#include "gdal/ogrsf_frmts.h"
#pragma once

class CReaderEnvi
{
static void InitialEnvi()// ��̬����������ʹ��դ���֮ǰ��ִ�и÷���
{
	GDALAllRegister();
	OGRRegisterAll();
};
}