
#define ISLIB

#if defined(ISLIB) && defined(WIN32)
#  ifdef LIB_MD_API_EXPORT
#    define MD_API_EXPORT __declspec(dllexport)
#  else
#    define MD_API_EXPORT __declspec(dllimport)
#  endif
#  ifdef LIB_TRADER_API_EXPORT
#    define TRADER_API_EXPORT __declspec(dllexport)
#  else
#    define TRADER_API_EXPORT __declspec(dllimport)
#  endif
#  ifdef LIB_API_EXPORT
#    define API_EXPORT __declspec(dllexport)
#  else
#    define API_EXPORT __declspec(dllimport)
#  endif
#else
#  define MD_API_EXPORT
#  define TRADER_API_EXPORT
#  define API_EXPORT
#endif