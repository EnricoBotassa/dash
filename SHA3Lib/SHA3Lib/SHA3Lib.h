#pragma once

#ifndef XCOIN_H
#define XCOIN_H


#ifdef LIBRARY_EXPORTS
#    define LIBRARY_API __declspec(dllexport)
#else
#    define LIBRARY_API __declspec(dllimport)
#endif

extern "C" LIBRARY_API void xcoin_hash	( const char* input, char* output, const int in_size);
extern "C" LIBRARY_API void blake512	( const char* input, char* output, const int in_size);
extern "C" LIBRARY_API void bmw512		( const char* input, char* output, const int in_size);
extern "C" LIBRARY_API void groestl512	( const char* input, char* output, const int in_size);
extern "C" LIBRARY_API void skein512	( const char* input, char* output, const int in_size);
extern "C" LIBRARY_API void jh512		( const char* input, char* output, const int in_size);
extern "C" LIBRARY_API void keccak512	( const char* input, char* output, const int in_size);
extern "C" LIBRARY_API void luffa512	( const char* input, char* output, const int in_size);
extern "C" LIBRARY_API void cubehash512	( const char* input, char* output, const int in_size);
extern "C" LIBRARY_API void shavite512	( const char* input, char* output, const int in_size);
extern "C" LIBRARY_API void simd512		( const char* input, char* output, const int in_size);
extern "C" LIBRARY_API void echo512		( const char* input, char* output, const int in_size);

#endif
