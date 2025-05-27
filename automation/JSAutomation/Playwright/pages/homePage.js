export class HomePage {
    /**
     * @param {import('@playwright/test').Page} page
     */
    constructor(page) {
      this.page = page;
      this.searchInput = '#txtGlobalSearch';
    }
  
    async goto() {
      await this.page.goto('https://dou.ua/');
    }
  
    async search(text) {
      await this.page.fill(this.searchInput, text);
      await this.page.keyboard.press('Enter');
    }
  }
  