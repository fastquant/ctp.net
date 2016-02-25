#include <iostream>
#include "SimpleLib.h"

int nSimpleLib=0;

int fnSimpleLib(void)
{
    return 42;
}

int cfnNotExportedSimpleLib(void)
{
	return 42;
}

int cfnExportedSimpleLib(void)
{
	return 42;
}

CSimpleLib::CSimpleLib()
{
	this->Value = 11;
    return;
}

class CSimpleLibImpl : public CSimpleLib {
public:
	void Init() {
		pCb->OnFrontConnected();
	}

	void RegisterInfo(Info *pInfo) {
		std::cout << "RegisterInfo Called" << std::endl;
	}

	void RegisterCallback(SimpleCallback *pCb) {
		this->pCb = pCb;
		std::cout << "RegisterCallback Called" << std::endl;
	}
private:
	SimpleCallback *pCb;
};

CSimpleLib * CSimpleLib::Create(const char * name)
{
	return new CSimpleLibImpl();
}

