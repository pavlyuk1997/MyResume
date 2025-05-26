import { test, expect } from '@playwright/test';

test('Search for "Automation" on DOU', async ({ page }) => {
  await page.goto('https://dou.ua/');
  await page.fill('#txtGlobalSearch', 'Automation');
  await page.keyboard.press('Enter');

  await page.waitForSelector('input[name="search"]');

  const value = await page.inputValue('input[name="search"]');
  expect(value).toBe('Automation');

  await page.waitForSelector('//div[@class="gsc-webResult gsc-result"]');
  const results = await page.$$('//div[@class="gsc-webResult gsc-result"]');
  expect(results.length).toBeGreaterThan(0);
});