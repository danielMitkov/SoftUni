window.addEventListener('load', solve);
function solve() {
  const loadBtn = document.getElementById('load-product');
  const addBtn = document.getElementById('add-product');
  const updateBtn = document.getElementById('update-product');
  const tbody = document.getElementById('tbody');

  const productInput = document.getElementById('product');
  const countInput = document.getElementById('count');
  const priceInput = document.getElementById('price');

  loadBtn.addEventListener('click', async (event) => {
    event.preventDefault();
    const response = await fetch('http://localhost:3030/jsonstore/grocery/');
    const data = await response.json();
    tbody.innerHTML = '';
    for (let obj of Object.values(data)) {
      const tr = document.createElement('tr');
      tbody.appendChild(tr);

      const tdName = document.createElement('td');
      tdName.classList.add('name');
      tdName.textContent = obj.product;
      tr.appendChild(tdName);

      const tdCount = document.createElement('td');
      tdCount.classList.add('count-product');
      tdCount.textContent = obj.count;
      tr.appendChild(tdCount);

      const tdPrice = document.createElement('td');
      tdPrice.classList.add('product-price');
      tdPrice.textContent = obj.price;
      tr.appendChild(tdPrice);

      const tdBtns = document.createElement('td');
      tdBtns.classList.add('btn');
      tr.appendChild(tdBtns);

      const btnUpdate = document.createElement('button');
      btnUpdate.classList.add('update');
      btnUpdate.textContent = 'Update';
      btnUpdate.addEventListener('click', async () => {
        productInput.value = obj.product;
        countInput.value = obj.count;
        priceInput.value = obj.price;
        addBtn.disabled = true;
        updateBtn.disabled = false;
        updateBtn.objId = obj._id;
      });
      tdBtns.appendChild(btnUpdate);

      const btnDelete = document.createElement('button');
      btnDelete.classList.add('delete');
      btnDelete.textContent = 'Delete';
      btnDelete.addEventListener('click', async () => {
        await fetch(`http://localhost:3030/jsonstore/grocery/${obj._id}`, { method: 'DELETE' });
        loadBtn.click();
      });
      tdBtns.appendChild(btnDelete);
    }
  });
  addBtn.addEventListener('click', async (event) => {
    event.preventDefault();
    await fetch('http://localhost:3030/jsonstore/grocery/', {
      method: 'POST',
      body: JSON.stringify({
        product: productInput.value,
        count: countInput.value,
        price: priceInput.value
      })
    });
    productInput.value = '';
    countInput.value = '';
    priceInput.value = '';
    loadBtn.click();
  });
  updateBtn.addEventListener('click', async () => {
    await fetch(`http://localhost:3030/jsonstore/grocery/${updateBtn.objId}`, {
      method: 'PATCH',
      body: JSON.stringify({
        product: productInput.value,
        count: countInput.value,
        price: priceInput.value
      })
    });
    productInput.value = '';
    countInput.value = '';
    priceInput.value = '';
    updateBtn.disabled = true;
    addBtn.disabled = false;
    loadBtn.click();
  });
}