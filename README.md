[![Version](https://img.shields.io/badge/Rimworld-1.3-green.svg)](http://rimworldgame.com/) [![Version](https://img.shields.io/badge/Rimworld-1.4-green.svg)](http://rimworldgame.com/) [![Version](https://img.shields.io/badge/Rimworld-1.5-green.svg)](http://rimworldgame.com/)[![Version](https://img.shields.io/badge/Rimworld-1.6-green.svg)](http://rimworldgame.com/)
[![GitHub release (latest by date)](https://img.shields.io/github/v/release/angelolocritani/Rimworld-AnimalsAgeFilter)](https://github.com/angelolocritani/Rimworld-AnimalsAgeFilter/releases/latest)
---
# More filters for animals' pen

![AnimalsAgeFilterPreview](https://i.imgur.com/ytA1skj.png)

![AnimalsAgeFilterExample](https://i.imgur.com/QxpG5MO.png)

A simple QOL mod that allow to filter animals's pen content based on
- their age (baby/juvenile/adult);
- pregnancy/fertilization status;
- sterilization status;
- age greater than life expectancy of animals' race;
- if a pack animal is carrying items;
- an immediate or periodic needs for tending;
- designation for slaughtering;
- malnutrition status;
- with resources ready to be harvested
- with all injuries tended
- with permanent injuries
- with name

## IMPORTANT NOTES

- safe to add to an ongoing game
- to remove from an ongoing game it's best to allow all pen filters, save the game, and only then remove the mod

## COMPLEX LOGIC (vanilla feature)

You can combine several filters putting multiple pen marker in the same pen:
- what is really important (and what is indeed saved in savegame) is what you do *not* allow;
- a single marker applies AND logic on all its terms;
- if you have multiple markers in the same pen the OR logic is applied between them

For example if you want to keep sterilized males + all females in the same pen you just put:
- pen marker 1 -> no females, no unsterilized (so basically only sterilized males);
- pen marker 2 -> no males (so basically only females)

if both are in the same pen the applied logic is:  
(not female AND not unsterilized) OR (not male)

---
[![Steam download](https://img.shields.io/steam/downloads/2558978295?logo=steam)](https://steamcommunity.com/sharedfiles/filedetails/?id=2558978295)
[![Download from Ludeon](https://img.shields.io/static/v1?label=download&color=f9b05a&message=from%20Ludeon&logo=data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA4AAAAOCAYAAAAfSC3RAAABgmlDQ1BJQ0MgcHJvZmlsZQAAKJF9kTtIA0EYhD+jEhXFwhQiFldEKwOiIpYSRREMSIyQqIV3FxOF3BnuIjaWgm3Awkfjq7Cx1tbCVhAEHyB2dlaKNhLOf5NAghgXlv2Y3Rl2Z8F3lDEtt6EfLDvnRCfDWjwxr/lfaaYDP0HQTTcbmZ2IUXN83VOn1ruQyqp97s/Rllx2TajThEfNrJMTXhIe3shlFe8JB8wVPSl8LtznyAWFH5VulPhNcbrIPpUZcGLRMeGAsJauYqOKzRXHEh4SDiYtW/J98RInFW8qtjLrZvme6oWty/bcrNJldjPJFBFm0DBYZ5UMOUKy2qK4RGU/XMPfVfTPiMsQ1yqmOMZZw0Iv+lF/8LtbNzU4UEpqDUPji+d99IB/Bwp5z/s+9rzCCdQ/w5Vd8a8dwcin6PmKFjyE9i24uK5oxi5cbkPnU1Z39KJUL9OXSsH7mXxTAjpuoWWh1Ft5n9MHiElX0zewfwC9aclerPHupure/j1T7u8HPoByklgoBiIAAAAGYktHRAD/AP8A/6C9p5MAAAAJcEhZcwAACxMAAAsTAQCanBgAAAAHdElNRQflCRMHKxnStfm9AAAA8UlEQVQoz5XSPUsDQRSF4ScSXBULe60UtPMLbU1jIzYDFsL8J/0ZW08l1oKiRcDG0kIQwcbCRgZjtNlIWHZjvOWd8945h3s7kFNcxB66JtcX+kUo3zs5xSX0sWq6esbuDA7+AcEKDrst9jIuKmvHmK+9z7ZBvSKUd1X+bVxjYVw00wBejiAoQnmPVBc1gd/T9JrAo5zi/q/vFLcQ6qKmjAWucorr+MBNPZ8JC5+rBgyaoDar8IYnvOKlDRzWTuoR50UoP4tQDnFW9Qbjuk5OcRkP1ZJ7RShvm37IKe5U+xxic9Rcyyme/nVrOcWTnOIG/AAWakZLeHxQnQAAAABJRU5ErkJggg==)](https://ludeon.com/forums/index.php?topic=54893.0)
