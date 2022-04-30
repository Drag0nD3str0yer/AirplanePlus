SCRIPT_DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" &> /dev/null && pwd )"
source ${SCRIPT_DIR}/../CONFIG.inc

PACKAGE=AirplanePlus
TARGETDIR="$PACKAGE"
TARGETBINDIR="$TARGETDIR/Plugins"
PROJECTSDIR="$PACKAGE/"
VERSIONFILE="AirplanePlus.version"
DLLS=""
PD_DLLS=""
GD_DLLS=""
GD_PRIORITY="999"

PROJECT_BRANCH=`git branch | grep \* | cut -d ' ' -f2`
if [ "$PROJECT_BRANCH" == "master" ] ; then
    # Release mode
    PROJECT_STATE="-BETA"
else
    # Note: Add a leading dash when this value is present!
    PROJECT_STATE="-BETA"
fi

VERSION=$( cat $VERSIONFILE | tr '\n' ' ' | sed -n -E 's/^.*?"VERSION\":\{.*"MAJOR":([0-9]+?),.*?"MINOR":([0-9]+?),.*?"PATCH":([0-9]+?),.*?"BUILD":([0-9]+?).*?\}.*$/\1.\2.\3.\4/p' )