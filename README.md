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
Please write [documentation comments](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments)
sample as follow:
```cs
/// <value>Property <c>X</c> represents the point's x-coordinate.</value>
public int X
{
   get { return x; }
   set { x = value; }
}
```

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