async function loadEmployees(sort = "asc") {
    try {
        const url = `/Employee/GetAllEmployee?sort=${sort}`; // Controller/Action URL
        const response = await fetch(url, {
            method: "GET",
            headers: {
                "Content-Type": "application/json"
            }
        });

        if (!response.ok) {
            throw new Error("Request failed: " + response.status);
        }

        const data = await response.json();
      
        // HTML table və ya listi doldura bilərsən
        renderEmployees(data.employee);
    } catch (error) {
        console.error(error);
    }
}

//<div id="employeeTableContainer"></div>

let currentSort = "asc";
function renderEmployeeTable() {
    const container = document.getElementById("employeeTableContainer");

    container.innerHTML = `
        <div style="margin-bottom: 15px;">
  
        <button id="sortBtn">Sort: ${currentSort.toUpperCase()}</button>
            <button id="addEmployeeBtn">Add Employee</button>
           
        </div>

        <div>
        Total Employees: <span id="totalCount">0</span>
    </div>

        <table border="1" cellpadding="5" cellspacing="0">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Full Name</th>
                    <th>Position</th>
                    <th>Department</th>
                    <th>Hire Date</th>
                    <th>Email</th>
                    <th>Phone</th>
                    <th>Salary</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody id="employeesTableBody">
                <!-- JS ilə doldurulacaq -->
            </tbody>
        </table>
    `;

    // Add Employee düyməsi üçün event
    document.getElementById("addEmployeeBtn").addEventListener("click", () => {

        const container = document.getElementById("employeeTableContainer");
        document.innerHTML = ""
        console.log(Sa);

        // Burada modal və ya form açmaq olar
    });
}

// İstədiyin yerdə çağırmaq üçün
renderEmployeeTable();



// Məsələn table render funksiyası
function renderEmployees(employees) {

    const tbody = document.getElementById("employeesTableBody");
    const totalCountSpan = document.getElementById("totalCount");

    console.log("Gələn data:", employees);
    console.log("Gələn data:", employees.totalCount);
    console.log("Gələn data:", employees);              

    tbody.innerHTML = "";

    // 🔥 TOTAL COUNT-u göstər
    totalCountSpan.textContent = employees.totalCount;
    employees.forEach(emp => {
        const tr = document.createElement("tr");
        tr.innerHTML = `
            <td>${emp.employeeId}</td>
            <td>${emp.fullName}</td>
            <td>${emp.position}</td>
            <td>${emp.department}</td>
            <td>${emp.hireDate}</td>
            <td>${emp.email || ""}</td>
            <td>${emp.phone || ""}</td>
            <td>${emp.salary || ""}</td>
        `;
        tbody.appendChild(tr);
    });
}

// Çağırmaq üçün
 loadEmployees("asc"); // sort = desc













function renderEmployees(employees) {
    const tbody = document.getElementById("employeesTableBody");
    tbody.innerHTML = ""; // əvvəlki sətirləri təmizlə

    employees.forEach(emp => {
        const tr = document.createElement("tr");
        tr.innerHTML = `
            <td>${emp.employeeId}</td>
            <td>${emp.fullName}</td>
            <td>${emp.position}</td>
            <td>${emp.department}</td>
            <td>${emp.hireDate}</td>
            <td>${emp.email || ""}</td>
            <td>${emp.phone || ""}</td>
            <td>${emp.salary || ""}</td>
            <td>
                <button class="updateBtn" data-id="${emp.employeeId}">Update</button>
                <button class="deleteBtn" data-id="${emp.employeeId}">Delete</button>
            </td>
        `;
        tbody.appendChild(tr);
    });

    // Düymələr üçün event listener-lər
    document.querySelectorAll(".updateBtn").forEach(btn => {
        btn.addEventListener("click", () => {
            const id = btn.getAttribute("data-id");
            alert("Update clicked for ID: " + id);
            // Burada modal açıb update funksiyasını çağırmaq olar
        });
    });

    document.querySelectorAll(".deleteBtn").forEach(btn => {
        btn.addEventListener("click", () => {
            const id = btn.getAttribute("data-id");
            alert("Delete clicked for ID: " + id);
            // Burada delete API request atmaq olar
        });
    });
}

// Add Employee düyməsi
document.getElementById("addEmployeeBtn").addEventListener("click", () => {
    alert("Add Employee clicked");
    // Burada add modal və ya form göstərmək olar
});

document.getElementById("sortBtn").addEventListener("click", async () => {
    currentSort = currentSort === "asc" ? "desc" : "asc";
    
    document.getElementById("sortBtn").textContent = `Sort: ${currentSort.toUpperCase()}`;
    await loadEmployees(currentSort); // Yenidən data yüklə
});

// İlk data yükləmə
loadEmployees("asc");

