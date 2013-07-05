#include "gdal/gdal.h"
#include "gdal/ogrsf_frmts.h"
#pragma once

class CReaderEnvi
{
static void InitialEnvi()// 静态方法，请在使用栅格库之前先执行该方法
{
	GDALAllRegister();
	OGRRegisterAll();
};
}