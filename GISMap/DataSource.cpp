//## begin module%1.2%.codegen_version preserve=yes
//   Read the documentation to learn more about C++ code generator
//   versioning.
//## end module%1.2%.codegen_version

//## begin module%405A768B0257.cm preserve=no
//	  %X% %Q% %Z% %W%
//## end module%405A768B0257.cm

//## begin module%405A768B0257.cp preserve=no
//## end module%405A768B0257.cp

//## Module: DataSource%405A768B0257; Pseudo Package body
//## Source file: E:\egis\code\DataAccess\DataSource.cpp

//## begin module%405A768B0257.additionalIncludes preserve=no
//## end module%405A768B0257.additionalIncludes

//## begin module%405A768B0257.includes preserve=yes
//## end module%405A768B0257.includes

#include "DataSource.h"
//## begin module%405A768B0257.additionalDeclarations preserve=yes
#include "FeatureClass.h"
//## end module%405A768B0257.additionalDeclarations


// Class DataSource 









DataSource::DataSource()
  //## begin DataSource::DataSource%405A768B0257_const.hasinit preserve=no
  //## end DataSource::DataSource%405A768B0257_const.hasinit
  //## begin DataSource::DataSource%405A768B0257_const.initialization preserve=yes
  //## end DataSource::DataSource%405A768B0257_const.initialization
{
  //## begin DataSource::DataSource%405A768B0257_const.body preserve=yes
  //## end DataSource::DataSource%405A768B0257_const.body
}


DataSource::~DataSource()
{
  //## begin DataSource::~DataSource%405A768B0257_dest.body preserve=yes
	MAP_DataSet::iterator map_i;
	DataSet *pdataset;
	for( map_i = m_mapDataSet.begin(); map_i != m_mapDataSet.end(); map_i++)
	{
		pdataset = ( DataSet* )(*map_i).second;
		delete (FeatureClass*)pdataset;
		(*map_i).second = 0 ;
	}
	m_mapDataSet.clear();
  //## end DataSource::~DataSource%405A768B0257_dest.body
}

DataSet& DataSource::CreateDataSet (int id, int type, const char* strName)
{
  //## begin DataSource::CreateDataSet%405BF6B303C8.body preserve=yes
	DataSet *pdataset = new FeatureClass( id, type, strName, this );
	m_mapDataSet.insert( MAP_DataSet::value_type( id, pdataset ) );
	return *pdataset;
  //## end DataSource::CreateDataSet%405BF6B303C8.body
}

int DataSource::Size ()
{
  //## begin DataSource::Size%405BF7B10128.body preserve=yes
	return m_mapDataSet.size();
  //## end DataSource::Size%405BF7B10128.body
}

DataSet& DataSource::GetDataSet (int id)
{
  //## begin DataSource::GetDataSet%405BF79C02BF.body preserve=yes
	DataSet *pdatasets;
	MAP_DataSet::iterator map_i = m_mapDataSet.find( id );
	if( map_i != m_mapDataSet.end() )
	{
		pdatasets = (DataSet*)(*map_i).second;
		return *pdatasets;
	}
  //## end DataSource::GetDataSet%405BF79C02BF.body
}

DataSet* DataSource::GetFirstDataSet ()
{
  //## begin DataSource::GetFirstDataSet%405BF77F0167.body preserve=yes
	m_curIterator = m_mapDataSet.begin();
	if( m_curIterator != m_mapDataSet.end() )
	{
		return (DataSet*)(*m_curIterator).second;
	}
	else
	{
		return 0;
	}
  //## end DataSource::GetFirstDataSet%405BF77F0167.body
}

DataSet* DataSource::GetNextDataSet ()
{
  //## begin DataSource::GetNextDataSet%405BF78D0203.body preserve=yes
	if( m_curIterator != m_mapDataSet.end() )
	{
		m_curIterator++;
		if( m_curIterator != m_mapDataSet.end() )
		{
			return (DataSet*)(*m_curIterator).second;
		}
	}
	return 0;
  //## end DataSource::GetNextDataSet%405BF78D0203.body
}

//## end module%405A768B0257.epilog

int DataSource::GetUniqueID()
{
	return m_mapDataSet.size() + 1 ;
}
