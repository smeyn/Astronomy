#-------------------------------------------------------------------------------
#
# makefile
#
# Purpose:
#
#   Linux make file for C++ library and programs of
#   "O. Montenbruck, Th. Pfleger; Astronomy on the Personal Computer (4th ed.)"
#
# Notes:
#
#   To build the executable programs, copy all source and header files (*.cpp,
#   *.h) as well as this makefile into the working directory:
#      >tar -xvf /cdrom/APCe/Linux/apcesrc.tar
#      >cp /cdrom/APCe/Linux/makefile .
#   Then start the make tool:
#      >make
# 
#-------------------------------------------------------------------------------

#Compilation options
CXXFLAGS +=  -O3 -Wall 

# The library is
LIB=libAPC.a

# and is made from the following object files
LIBOBJS=APC_Cheb.o APC_DE.o APC_IO.o APC_Kepler.o APC_Math.o APC_Moon.o \
APC_Phys.o APC_Planets.o APC_PrecNut.o APC_Spheric.o \
APC_Sun.o APC_Time.o APC_VecMat3D.o

# The application files themselves are
APPLICS=AOEcat Coco Comet Eclipse EclTimer Foto Gauss Luna Numint \
Occult Phases Phys Planpos Planrise PPMbin PPMcat Sunset

# Our main target is to make all the applications:
all: $(APPLICS)

# The library is made from the object files by using 'ar'
libAPC.a: $(LIBOBJS)
	ar rc $(LIB) $(LIBOBJS)

# Each of the application files, in addition to being dependant on its
# own source file, needs the library
$(APPLICS): $(LIB)

# The next two are just to clean up files which we may not need to keep
# Clean up all the object files that are now in the library
clean:
	@rm -f $(LIBOBJS)

# Clobber all the generated files, including the library and applications
clobber: clean
	@rm -f $(LIB) $(APPLICS)

