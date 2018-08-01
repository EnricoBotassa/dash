
Debian
====================
This directory contains files used to package zalgocoind/zalgocoin-qt
for Debian-based Linux systems. If you compile zalgocoind/zalgocoin-qt yourself, there are some useful files here.

## zalgocoin: URI support ##


zalgocoin-qt.desktop  (Gnome / Open Desktop)
To install:

	sudo desktop-file-install zalgocoin-qt.desktop
	sudo update-desktop-database

If you build yourself, you will either need to modify the paths in
the .desktop file or copy or symlink your zalgocoin-qt binary to `/usr/bin`
and the `../../share/pixmaps/zalgocoin128.png` to `/usr/share/pixmaps`

zalgocoin-qt.protocol (KDE)

