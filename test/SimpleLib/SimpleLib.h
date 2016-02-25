#ifdef SIMPLELIB_EXPORTS
#define SIMPLELIB_API __declspec(dllexport)
#else
#define SIMPLELIB_API __declspec(dllimport)
#endif

typedef int SizeType;

// SimpleKind Comment
enum SimpleKind
{
	SK_EASY = 0,
	SK_NORMAL,
	SK_HARD
};

typedef char TraderIDType[21];
typedef char InvestorIDType[13];

#define RULE_Create '0'
#define RULE_NotCreate '1'
typedef char CreateRuleType;

struct Info {
	int field1;
	double field2;
	TraderIDType TradeID;
	InvestorIDType InvestorID;
	CreateRuleType Rule;
	Info() {
		field1 = 10;
		field2 = 0.5;
	}
};

class SimpleCallback
{
public:
	virtual void OnFrontConnected() {};
};

class SIMPLELIB_API CSimpleLib {
public:
	int Value;
	CSimpleLib(void);
	static CSimpleLib *Create(const char *name = "simple");
	virtual void Init() = 0;
	virtual void RegisterInfo(Info *pInfo) = 0;
	virtual void RegisterCallback(SimpleCallback *pCb) = 0;
protected:
	~CSimpleLib() {};
};

extern SIMPLELIB_API int nSimpleLib;

SIMPLELIB_API int fnSimpleLib(void);

extern "C" int cfnNotExportedSimpleLib(void);

extern "C" SIMPLELIB_API int cfnExportedSimpleLib(void);

