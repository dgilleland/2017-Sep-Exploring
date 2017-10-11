var users = [...document.querySelector("table.userenrolment").querySelectorAll("tbody tr")].map(row=>row.querySelector("td").innerText.split("\n").filter(String))
