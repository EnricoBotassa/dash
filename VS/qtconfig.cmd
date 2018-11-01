if "%1"=="" goto :end
SET VSSDir=%~d0%~p0
pushd %~f1\Src\qtbase
if exist makefile nmake distclean
if not exist mkspecs\win32-msvcMTx64 md mkspecs\win32-msvcMTx64
@echo include(../common/msvc-desktop.conf) > mkspecs\win32-msvcMTx64\qmake.conf
@echo QMAKE_CFLAGS_RELEASE    = $$QMAKE_CFLAGS_OPTIMIZE -MT>> mkspecs\win32-msvcMTx64\qmake.conf
@echo QMAKE_CFLAGS_RELEASE_WITH_DEBUGINFO = $$QMAKE_CFLAGS_OPTIMIZE -MT -Zi>> mkspecs\win32-msvcMTx64\qmake.conf
@echo QMAKE_CFLAGS_DEBUG      = -Zi -MTd>> mkspecs\win32-msvcMTx64\qmake.conf
@echo QMAKE_CXXFLAGS_RELEASE  = $$QMAKE_CFLAGS_RELEASE>> mkspecs\win32-msvcMTx64\qmake.conf
@echo QMAKE_CXXFLAGS_RELEASE_WITH_DEBUGINFO = $$QMAKE_CFLAGS_RELEASE_WITH_DEBUGINFO>> mkspecs\win32-msvcMTx64\qmake.conf
@echo QMAKE_CXXFLAGS_DEBUG    = $$QMAKE_CFLAGS_DEBUG>> mkspecs\win32-msvcMTx64\qmake.conf
@echo load(qt_config) >> mkspecs\win32-msvcMTx64\qmake.conf
copy /y mkspecs\win32-msvc\qplatformdefs.h mkspecs\win32-msvcMTx64\qplatformdefs.h
echo "y" | configure -debug-and-release -opensource -confirm-license -no-opengl -no-openvg -static -qt-libpng -gif -no-harfbuzz -platform win32-msvcMTx64 -nomake examples -nomake tests -style-windowsvista -prefix "%~f1\msvc_2017_MTx64" -openssl -openssl-linked -I "%VSSDir%openssl\include" -L "%LIB%" OPENSSL_LIBS="-lGdi32" OPENSSL_LIBS_DEBUG="-l%VSSDir%x64\Debug\openssl.lib" OPENSSL_LIBS_RELEASE="-l%VSSDir%x64\Release\openssl.lib" 
nmake
nmake install

popd
:end