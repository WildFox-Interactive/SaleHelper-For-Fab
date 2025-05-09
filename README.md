# 🏩 Product Sale Manager (Sale Manager)

**Product Sale Manager** is a Windows Forms application written in C# that allows you to manage a list of scheduled product sales. It supports creating, editing, importing, and exporting sales data with ease.

---

## 📦 Features

* Add and edit sales for products
* Set start and end dates (with automatic duration rules)
* Export to `solde.txt` in required format
* Maintain product name-to-URL mapping in `Product.txt`
* Import existing sales and product names
* Highlight sales active during a selected period
* Copy export content directly to clipboard
* Automatically enforce 14-day sale durations (with optional overrides)

---

## 🗓️ File Formats

### `solde.txt`

Stores sales in the following format (tab-separated):

```
<URL>    <StartDate (MM/dd/yyyy)>    <EndDate (MM/dd/yyyy)>    <PercentageOff>
```

Example:

```
https://fab.com/item/12345    05/22/2025    06/05/2025    50
```

### `Product.txt`

Stores the name associated with each URL:

```
Product Name = URL
```

This allows the UI to display readable product names next to each sale.

---

## 🖥️ How to Use

1. **Launch the Program**
   The app will automatically load `Product.txt` and `solde.txt` if they exist.

2. **Add a New Product Sale**

   * Enter product name and URL
   * Choose a **start date** (minimum 14 days after today)
   * End date auto-fills to 14 days later
   * Optionally change end date (check “Modifier la date de fin manuellement” to unlock)
   * Set discount percentage (default is 50)
   * Click **“Ajouter”** to save the item to the list

3. **Edit an Existing Sale**

   * Click a sale in the list to load its data into fields
   * Make edits and click **“Actualiser ligne”**
   * Product name and files update automatically

4. **Delete a Product Sale**

   * Select an item and click **“Supprimer”**

5. **Export/Import Files**

   * Menu → File → **Exporter**: save to `solde.txt` and `Product.txt`
   * Menu → File → **Importer**: load from `solde.txt`

6. **Copy to Clipboard**

   * Click “Copier dans le presse-papier” to copy the full content of `solde.txt` format

7. **Highlight Sales in a Period**

   * Choose a check start and end date
   * (Optional) Check "Ajouter 30 jours à la date de fin"
   * Click **"Vérifier période"** to highlight matching sales in red

8. **Next Rotation**

   * Select a sale, click “Next rotation”
   * Moves sale to next cycle: `newStart = oldEnd + 31 days`
   * Prevents shifts over 60 days from current date


## 💡 Notes

* `Product.txt` is automatically saved/updated on every change (add, edit, delete).
* End date is restricted to **14 days** after start date unless manual override is enabled.
* Start date must be **at least 14 days from today**.
