/** @type {import('@docusaurus/types').DocusaurusConfig} */
module.exports = {
    title: "RSM.HCD.CSharp.Core",
    tagline:
        "Commonly used interfaces, patterns and utilities by andculture engineering",
    url: "https://rsm-hcd.github.io",
    baseUrl: "/RSM.HCD.CSharp.Core/",
    onBrokenLinks: "throw",
    onBrokenMarkdownLinks: "warn",
    favicon: "img/favicon.ico",
    organizationName: "rsm-hcd",
    projectName: "RSM.HCD.CSharp.Core",
    themeConfig: {
        prism: {
            additionalLanguages: ["csharp"],
        },
        navbar: {
            title: "RSM.HCD.CSharp.Core",
            logo: {
                alt: "RSM.HCD.CSharp.Core",
                src: "img/logo.jpg",
            },
            items: [
                {
                    href: "https://github.com/rsm-hcd/RSM.HCD.CSharp.Core",
                    label: "GitHub",
                    position: "right",
                },
            ],
        },
        footer: {
            style: "dark",
            links: [
                {
                    title: "Community",
                    items: [
                        {
                            label: "Github",
                            href: "https://github.com/rsm-hcd",
                        },
                    ],
                },
            ],
            copyright: `Copyright © ${new Date().getFullYear()} RSM US, LLP. Built with Docusaurus.`,
        },
    },
    presets: [
        [
            "@docusaurus/preset-classic",
            {
                docs: {
                    sidebarPath: require.resolve("./sidebars.ts"),
                    // Please change this to your repo.
                    editUrl:
                        "https://github.com/facebook/docusaurus/edit/master/website/",
                },
                blog: {
                    showReadingTime: true,
                    // Please change this to your repo.
                    editUrl:
                        "https://github.com/facebook/docusaurus/edit/master/website/blog/",
                },
                theme: {
                    customCss: require.resolve("./src/css/custom.css"),
                },
            },
        ],
    ],
};
