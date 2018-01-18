# Using GitBook

Just a little experiment on using GitBook documentation. Imagine, for example, I wanted to use some MarkDown to generate some documentation, but wanted to do a little bit of Markup as well (to demonstrate CSS Grid or Flexbox for example). I could try something like this:

<section id="faux-body">
    <main>
        <p>
            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sit amet posuere dolor, eu molestie quam. Mauris a mi laoreet, dapibus eros eget, volutpat lorem. Quisque non lacinia mi. Nunc ultricies bibendum orci, et sodales turpis egestas laoreet. In blandit magna ut rutrum tincidunt. Sed varius, sem vel aliquet dictum, dolor nulla vehicula lorem, non congue lectus massa sit amet turpis. Proin aliquam libero eu massa aliquet luctus. Nullam molestie dui felis, at porta mi pretium nec.
        </p>
    </main>
    <header>
        <h1>Welcome</h1>
    </header>
    <footer>&copy; 2018</footer>
    <nav>
        <ul>
            <li><a href="#">Home</a></li>
            <li><a href="#">About</a></li>
            <li><a href="#">Contact</a></li>
        </ul>
    </nav>
</section>

<style>
style[contenteditable="true"] {
    white-space:pre-wrap; 
    display:block;
    outline:none;
    border: groove 4px aqua;
    margin: 10px;
    padding: 0 8px;
}
</style>

You can play with editing the CSS for the HTML demo above by changing the code in the area below.

<style contenteditable="true">
    #faux-body {
        display: grid;
        grid-gap: 10px;
        width: 750px;
        background-color: lightgray;
        border: solid 1px blue;
    }

    #faux-body *, *:before, *:after {
    box-sizing: inherit;
    }
    #faux-body > nav {
        grid-row: 1;
    }
    #faux-body > header {
        grid-row: 2;
        padding: 5px;
    }
    #faux-body > main {
        grid-row: 3;
        padding: 5px;
    }
    #faux-body > footer {
        grid-row: 4;
        padding: 5px;
    }

    #faux-body > nav a {
        color: white;
        text-decoration: none;
        font-weight: bold;
    }
    #faux-body > nav > ul {
        display: flex;
        list-style: none;
        background-color: darkgray;
        font-size: 1.2em;
        padding: 0;
    }
    #faux-body > nav > ul > li {
        padding: 3px 8px;
        background-color: slategray;
        margin-right: 7px;
    }

    #faux-body > header > h1 {
        margin-top: .25em;
        margin-bottom: .64em;
    }
</style>

----

### Notes

The HTML for the above is this:

```html
<section id="faux-body">
    <main>
        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sit amet posuere dolor,
        eu molestie quam. Mauris a mi laoreet, dapibus eros eget, volutpat lorem. Quisque non
        lacinia mi. Nunc ultricies bibendum orci, et sodales turpis egestas laoreet. In blandit 
        magna ut rutrum tincidunt. Sed varius, sem vel aliquet dictum, dolor nulla vehicula lorem, 
        non congue lectus massa sit amet turpis. Proin aliquam libero eu massa aliquet luctus. 
        Nullam molestie dui felis, at porta mi pretium nec.</p>
    </main>
    <header>
        <h1>Welcome</h1>
    </header>
    <footer>&copy; 2018</footer>
    <nav>
        <ul>
            <li><a href="#">Home</a></li>
            <li><a href="#">About</a></li>
            <li><a href="#">Contact</a></li>
        </ul>
    </nav>
</section>
```

The CSS for the inlined demo is this:

```css
    #faux-body {
        display: grid;
        grid-gap: 10px;
        width: 750px;
        background-color: lightgray;
        border: solid 1px blue;
    }

    #faux-body *, *:before, *:after {
    box-sizing: inherit;
    }
    #faux-body > nav {
        grid-row: 1;
    }
    #faux-body > header {
        grid-row: 2;
        padding: 5px;
    }
    #faux-body > main {
        grid-row: 3;
        padding: 5px;
    }
    #faux-body > footer {
        grid-row: 4;
        padding: 5px;
    }

    #faux-body > nav a {
        color: white;
        text-decoration: none;
        font-weight: bold;
    }
    #faux-body > nav > ul {
        display: flex;
        list-style: none;
        background-color: darkgray;
        font-size: 1.2em;
        padding: 0;
    }
    #faux-body > nav > ul > li {
        padding: 3px 8px;
        background-color: slategray;
        margin-right: 7px;
    }

    #faux-body > header > h1 {
        margin-top: .25em;
        margin-bottom: .64em;
    }
```
