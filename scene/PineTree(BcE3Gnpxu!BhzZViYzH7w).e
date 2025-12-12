13
3942779977729
404954323786862 1761863310427062000
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -6.1083240509033203,
    "Y": -9.7910804748535156
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404952249567180:1761863309943766500",
  "next_sibling": "404955754513689:1761863310760423000",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404954324040648:1761863310427120400",
  "component_type": "Internal_Component",
  "internal_component_type": "Interactable",
  "data": {
    "text": "Harvest Pine Tree",
    "radius": 1,
    "required_hold_time": 0.3000000119209290
  }
},
{
  "cid": 4,
  "aoid": "404954324170379:1761863310427150600",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404954324040648:1761863310427120400",
    "DefaultRenderer": "404954324235739:1761863310427165800",
    "DepletedRenderer": "404954324210928:1761863310427160000"
  }
},
{
  "cid": 5,
  "aoid": "404954324185773:1761863310427154100",
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
}
