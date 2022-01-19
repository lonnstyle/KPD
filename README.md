# KPD
## Data Structure:<br/>
* all data should be stored in json format
```json
{
    "foo":"bar",
    "list_data":[1,2,3],
    "nested_dict":{
        "google":"chrome"
    }
}
```
---
## Documentation
Please write a docstring for all functions, especially those code which are not self-explaining<br/>
docstring formats as follow:
* [Google](https://google.github.io/styleguide/pyguide.html#38-comments-and-docstrings)
* [PEP 257](https://www.python.org/dev/peps/pep-0257/#specification)
* [Numpy](https://numpydoc.readthedocs.io/en/latest/format.html#docstring-standard)
* [reST](https://pythonhosted.org/an_example_pypi_project/sphinx.html#function-definitions)

Also, please add [Debug.log](https://docs.unity3d.com/ScriptReference/Debug.Log.html) for unity codes, it helps for checking codes are functioning well or not

---
## Commit
Please make an individual branch before merging into `main`, you can view all branches [here](https://github.com/lonnstyle/KPD/branches)<br/>
You can track status at [board](https://github.com/users/lonnstyle/projects/1/views/1?layout=board)<br/>
and make sure all your commit message should be in [semantic format](https://gist.github.com/joshbuchea/6f47e86d2510bce28f8e7f42ae84c716)
>```
>feat: add hat wobble
>^--^  ^------------^
>|     |
>|     +-> Summary in present tense.
>|
>+-------> Type: chore, docs, feat, fix, refactor, style, or test.
>```

---
## File Structure
currently all stuffs should goes into `unity` folder, as all stuffs are done in unity
* unity
  * Assets
    * Animation
    * Backgrounds
    * Fonts (all `TMP` presets)
    * Icons
    * Motion (source file of `Animation`)
    * Scenes
    * scripts
    * TextMesh Pro (package import)
  * Library (system generate)
  * Logs (system generate)
  * Packages (system generate)
  * ProjectSettings (don't edit directly, make changes in unity)
  * Temp (system generate)
  * UserSettings (don't edit directly, make changes in unity)