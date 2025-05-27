import { test, expect } from '@playwright/test';
import { HomePage } from '../pages/homePage.js'
import { SearchPage } from '../pages/searchPage.js';
import { VacancyPage } from '../pages/vacancyPage.js';

test('Search for "Automation" and check results', async ({ page }) => {
  const homePage = new HomePage(page);
  const searchPage = new SearchPage(page);
  const vacancyPage = new VacancyPage(page);

  await homePage.goto();
  await homePage.search('Automation');

  const searchValue = await searchPage.getSearchValue();
  expect(searchValue).toBe('Automation');

  await searchPage.waitForResults();
  const count = await searchPage.getResultsCount();
  expect(count).toBeGreaterThan(0);

  await searchPage.clickFirstVacancy();
  const title = await vacancyPage.getTitle();
  expect(title).not.toBeNull(); // Can be more specific if needed
});
