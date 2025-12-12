13
2972117368834
407832379605112 1761863981017046500
{
  "name": "OakTree",
  "local_enabled": true,
  "local_position": {
    "X": 14.8620214462280273,
    "Y": 2.0650930404663086
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "407818716499586:1761863977833528600",
  "next_sibling": "405816087092634:1761863511218804100",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "OakTree.prefab"
},
{
  "cid": 3,
  "aoid": "407832379891019:1761863981017112200",
  "component_type": "Internal_Component",
  "internal_component_type": "Interactable",
  "data": {
    "text": "Harvest Oak Tree",
    "radius": 1,
    "required_hold_time": 0.3000000119209290
  }
},
{
  "cid": 5,
  "aoid": "407832380005184:1761863981017138800",
  "component_type": "Internal_Component",
  "internal_component_type": "Polygon_Collider",
  "data": {
    "make_navmesh_loop": true,
    "flip_navmesh_loop": true,
    "points": [
      {
        "X": -0.1877212524414062,
        "Y": -0.2063050270080566
      },
      {
        "X": 0.0189009904861450,
        "Y": -0.2597980499267578
      },
      {
        "X": 0.2158927917480469,
        "Y": -0.1123766899108887
      },
      {
        "X": 0.0703394412994385,
        "Y": 0.1123763322830200
      },
      {
        "X": -0.1783308982849121,
        "Y": 0.0560193061828613
      }
    ]
  }
},
{
  "cid": 1,
  "aoid": "407832380038595:1761863981017146600",
  "component_type": "Mono_Component",
  "mono_component_type": "OakTree",
  "data": {
    "Interactable": "407832379891019:1761863981017112200",
    "DefaultRenderer": "407832380068050:1761863981017153500",
    "DepletedRenderer": "407832380051882:1761863981017149700"
  }
}
